using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
//using Synergy.Core.Data;
using System.Data;
//using Microsoft.Data.SqlClient;
//using SynergyApplicationFrameworkApi.Infrastructure.Helper;
//using SynergyApplicationFrameworkApi.Entities;
//using SynergyApplicationFrameworkApi.Enumerations;
//using SynergyApplicationFrameworkApi.Infrastructure.Factories;
//using SynergyApplicationFrameworkApi.Infrastructure.Repositories;
//using SynergyApplicationFrameworkApi.Controllers;

//using Microsoft.EntityFrameworkCore;
using SynergyApplicationFrameworkApi.Application.DTOs;
using SynergyApplicationFrameworkApi.Application.Interfaces;
using SynergyApplicationFrameworkApi.Application.Services;
using System.Linq.Expressions;

namespace SynergyApplicationFrameworkApi.Infrastructure.Repositories;

public class ContainerInstanceRepository : IContainerInstanceRepository
{
    private readonly OperativeDbContext _context;

    public ContainerInstanceRepository(OperativeDbContext context)
    {
        _context = context;
    }

    private Expression<Func<ContainerInstance, bool>> HasIdentifier(string scanString)
    {
        return ci =>
            !string.IsNullOrWhiteSpace(scanString) &&
            ci.ContainerInstanceIdentifier.Any(cii => cii.Value == scanString);
    }

    #region Basic Gets

    public async Task<ContainerInstance?> GetAsync(int id)
    {
        return await _context.ContainerInstances
            .Include(ci => ci.ContainerInstanceIdentifier)
                .ThenInclude(cii => cii.ContainerInstanceIdentifierType)
            .FirstOrDefaultAsync(ci => ci.ContainerInstanceId == id);
    }

    public async Task<List<ContainerInstance>> GetMultipleAsync(List<int> ids)
    {
        return await _context.ContainerInstances
            .Where(ci => ids.Contains(ci.ContainerInstanceId))
            .Include(ci => ci.ContainerInstanceIdentifier)
                .ThenInclude(cii => cii.ContainerInstanceIdentifierType)
            .ToListAsync();
    }

    public async Task<ContainerInstance?> ReadAsync(int id)
    {
        return await _context.ContainerInstances
            .Include(ci => ci.ContainerInstanceIdentifier)
                .ThenInclude(cii => cii.ContainerInstanceIdentifierType)
            .FirstOrDefaultAsync(ci => ci.ContainerInstanceId == id && ci.Archived == null);
    }

    #endregion

    #region Turnaround Queries

    public async Task<Turnaround?> GetLastTurnaroundAsync(int containerInstanceId)
    {
        return await _context.Turnarounds
            .Where(t => t.ContainerInstanceId == containerInstanceId)
            .OrderByDescending(t => t.Created)
            .FirstOrDefaultAsync();
    }

    public async Task<Turnaround?> GetLastTurnaroundAsync(int containerInstanceId, short facilityId)
    {
        return await _context.Turnarounds
            .Where(t => t.ContainerInstanceId == containerInstanceId &&
                        t.ContainerInstance.FacilityId == facilityId)
            .OrderByDescending(t => t.Created)
            .FirstOrDefaultAsync();
    }

    public async Task<Turnaround?> GetLastWeighedTurnaroundAsync(int containerInstanceId)
    {
        return await _context.Turnarounds
            .Where(t =>
                t.ContainerInstanceId == containerInstanceId &&
                t.TurnaroundEvent.Any(te =>
                    (te.EventTypeId == (short)TurnAroundEventTypeIdentifier.WeighedUsingPostWashTolerances ||
                     te.EventTypeId == (short)TurnAroundEventTypeIdentifier.WeighedUsingPreWashTolerances) &&
                    te.TurnaroundEventWeight.Any(tew =>
                        tew.WeightStatusId == (short)WeightStatus.Accepted ||
                        tew.WeightStatusId == (short)WeightStatus.Passed)))
            .OrderByDescending(t => t.TurnaroundId)
            .FirstOrDefaultAsync();
    }

    #endregion

    #region Live Turnaround Logic

    public async Task<Turnaround?> GetLastLiveTurnaroundAsync(int containerInstanceId)
    {
        var turnarounds = _context.Turnarounds
            .Include(t => t.TurnaroundEvent)
                .ThenInclude(te => te.Workflow)
            .Where(t => t.ContainerInstanceId == containerInstanceId);

        var latest = await turnarounds
            .OrderByDescending(t => t.Created)
            .FirstOrDefaultAsync();

        if (latest == null)
            return null;

        var lastWorkflow = latest.TurnaroundEvent
            .Where(te => te.Workflow != null)
            .OrderByDescending(te => te.Created)
            .ThenByDescending(te => te.TurnaroundEventId)
            .Select(te => te.Workflow)
            .FirstOrDefault();

        if ((latest.StartEventId != null || latest.LastEventId != null) &&
            (lastWorkflow == null || !lastWorkflow.IsEnd))
        {
            return latest;
        }

        return null;
    }

    #endregion

    #region Barcode Checks

    public async Task<bool> IsLastEventTypeReprintBarcodeAsync(int containerInstanceId)
    {
        var turnaround = await _context.Turnarounds
            .Where(t => t.ContainerInstanceId == containerInstanceId)
            .OrderByDescending(t => t.Created)
            .FirstOrDefaultAsync();

        if (turnaround == null)
            return false;

        var lastEvent = await _context.TurnaroundEvents
            .Where(e => e.TurnaroundId == turnaround.TurnaroundId)
            .OrderByDescending(e => e.Created)
            .FirstOrDefaultAsync();

        return lastEvent?.EventTypeId ==
               (int)TurnAroundEventTypeIdentifier.ReprintInstanceBarcode;
    }

    public async Task<bool> IsLastEventTypeLegacyInstanceBarcodeReplacedAsync(int containerInstanceId)
    {
        var turnaround = await _context.Turnarounds
            .Where(t => t.ContainerInstanceId == containerInstanceId)
            .OrderByDescending(t => t.Created)
            .FirstOrDefaultAsync();

        if (turnaround == null)
            return false;

        var lastEvent = await _context.TurnaroundEvents
            .Where(e => e.TurnaroundId == turnaround.TurnaroundId)
            .OrderByDescending(e => e.Created)
            .FirstOrDefaultAsync();

        return lastEvent?.EventTypeId ==
               (int)TurnAroundEventTypeIdentifier.LegacyInstanceBarcodeReplaced;
    }

    #endregion

    #region Existence Checks

    public async Task<bool> DeliveryPointContainsInstancesAsync(int deliveryPointId)
    {
        return await _context.ContainerInstances
            .AnyAsync(ci => ci.DeliveryPointId == deliveryPointId && ci.Archived == null);
    }

    public async Task<bool> ContainerInstancesHasServiceRequirementAsync(int serviceRequirementDefinitionId)
    {
        return await _context.ContainerInstances
            .AnyAsync(ci => ci.ServiceRequirementDefinitionId == serviceRequirementDefinitionId && ci.Archived == null);
    }

    #endregion

    #region Charges

    public async Task<ChargeList?> GetPrintBarcodeChargesAsync(int containerInstanceId)
    {
        return await _context.ContainerInstances
            .Where(c => c.ContainerInstanceId == containerInstanceId)
            .SelectMany(c => c.DeliveryPoint.CustomerDefinition.ChargeList)
            .Where(cl => cl.Archived == null &&
                         cl.ChargeListCategoryId == (byte)ChargeListCategoryIdentifier.BarcodeReplacement)
            .FirstOrDefaultAsync();
    }

    #endregion
}