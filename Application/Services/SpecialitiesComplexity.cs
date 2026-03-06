using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public static class SpecialitiesComplexity
    {
        /// <summary>
        /// Validation operation
        /// </summary>
        public static bool Validation(ScanAssetDataContract scanDC, List<ScanAssetDataContract> scanDcList, TurnAroundEventTypeIdentifier eventTypeId)
        {
            if ((eventTypeId == TurnAroundEventTypeIdentifier.TrayPrioritisation) || (eventTypeId == TurnAroundEventTypeIdentifier.FailedQualityAssurance) ||
                (eventTypeId == TurnAroundEventTypeIdentifier.StartPacking))
            {
                if (Check(scanDC, scanDcList) == false)
                {
                    return false;
                }
            }
            else if (eventTypeId == TurnAroundEventTypeIdentifier.QualityAssurance)
            {
                if (Check(scanDC, scanDcList) == false)
                {
                    return false;
                }
                else if (IndependentCheck(scanDC, scanDcList) == false)
                {
                    return false;
                }
            }

            return !scanDC.ErrorCode.HasValue;
        }

        /// <summary>
        /// Check operation
        /// </summary>
        public static bool Check(ScanAssetDataContract scanDC, List<ScanAssetDataContract> scanDcList)
        {
            bool passed = true;

            using (var workUnit = UnitOfWorkFactory.CreateOperativeEFUnitOfWork())
            {
                var userComplexityRepository = UserComplexityRepository.New( workUnit);
                var userSpecialities = userComplexityRepository.GetAllUserSpecialities(scanDC.UserId).ToList();

                foreach (var asset in scanDcList)
                {
                    if (asset.SpecialityId != 1)
                    {
                        if (userSpecialities.Count == 0 || userSpecialities.FirstOrDefault(u => u.SpecialityId == asset.SpecialityId) == null)
                        {
                            scanDC.ErrorCode = (int)ErrorCodes.UserSpecialityFail;
                            passed = false;
                            break;
                        }
                        else
                        {
                            passed = (userSpecialities.FirstOrDefault(u => u.SpecialityId == asset.SpecialityId && u.ComplexityId >= asset.ComplexityId) != null);

                            if (!passed)
                            {
                                scanDC.ErrorCode = (int)ErrorCodes.UserComplexityFail;
                                break;
                            }
                        }
                    }
                }
            }

            return passed;
        }

        /// <summary>
        /// IndependentCheck operation
        /// </summary>
        public static bool IndependentCheck(ScanAssetDataContract scanDC, List<ScanAssetDataContract> scanDcList)
        {
            bool passed = true;

            {
                var facilityRepository = FacilityRepository.New(workUnit);
                var facility = facilityRepository.Get((short)scanDC.FacilityId);

                if (facility != null)
                {
                    foreach (var dc in scanDcList)
                    {
                        var teEvent = scanDC.TurnaroundEvents.LastOrDefault(te => te.EventTypeId == (int)TurnAroundEventTypeIdentifier.TrayPrioritisation ||
                                                                    te.EventTypeId == (int)TurnAroundEventTypeIdentifier.FinishPacking);

                        if (teEvent != null)
                        {
                            var turnaroundEventRepository = TurnaroundEventRepository.New(workUnit);
                            var turnaroundEvent = turnaroundEventRepository.Get(teEvent.TurnaroundEventId);

                            if (turnaroundEvent != null)
                            {
                                var userRepository = UserRepository.New(workUnit);
                                var user = userRepository.Get(turnaroundEvent.CreatedUserId);

                                if ((turnaroundEvent.CreatedUserId == scanDC.UserId) &&
                                    ((dc.IndependentQaCheck) || ((facility.IndependentQualityAssuranceCheck) || ((user != null) && (user.IndependentQualityAssuranceCheck)))))
                                {
                                    scanDC.ErrorCode = (int)ErrorCodes.SameTPAndQAUser;
                                    passed = false;
                                }
                            }
                        }
                    }
                }
            }

            return passed;
        }
    }
}