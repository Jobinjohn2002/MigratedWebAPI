using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// EnvironmentModel
    /// </summary>
    public class EnvironmentModel
    {
        /// <summary>
        /// Gets or sets AssembliesTable
        /// </summary>
        public TableModel AssembliesTable { get; private set; }

        private readonly ITranslator _translator;

        public EnvironmentModel(ITranslator translator)
        {
            _translator = translator;
            BuildManager.GetReferencedAssemblies();

            var assemblies = AppDomain.CurrentDomain.GetAssemblies();

            AssembliesTable = BuildAssembliesTable(assemblies.OrderBy(a => a.FullName));
        }

        private TableModel BuildAssembliesTable(IEnumerable<Assembly> assemblies)
        {
            var group = "pages";
            var section = "sysadmin.environment.index";

            var dynamic = _translator.GetText(group, section, "Dynamic");
            var trusted = _translator.GetText(group, section, "Fully Trusted");

            var infos = assemblies
                .Select(a => new
                    {
                        Assembly = a,
                        Details = a.GetName()
                    })
                .OrderBy(a => a.Details.Name);

            var table = new TableModel(false, false)
            {
                Columns = new List<TableColumnModel>
                {
                    new TableColumnModel
                    {
                        Filterable = false,
                        Sortable = false,
                        Text = _translator.GetText(group, section, "Assembly Name"),
                    },
                    new TableColumnModel
                    {
                        Filterable = false,
                        Sortable = false,
                        Text = _translator.GetText(group, section, "Assembly Version")
                    },
                    new TableColumnModel
                    {
                        Filterable = false,
                        Sortable = false,
                        Text = _translator.GetText(group, section, "Assembly Attributes")
                    }
                },
                CssClass = "assemblies",
                CurrentPage = 1,
                ID = "AssembliesTable",
                OnGetTableCells = (index) =>
                {
                    var info = infos.ElementAt(index);

                    var attributes = new List<string>();

                    if (info.Assembly.IsDynamic)
                    {
                        attributes.Add(dynamic);
                    }

                    if (info.Assembly.IsFullyTrusted)
                    {
                        attributes.Add(trusted);
                    }

                    var rowModel = new RowModel
                    {
                        new TableCellModel
                        {
                            Value = info.Details.Name,
                            Tooltip = info.Assembly.IsDynamic ? null : info.Assembly.CodeBase
                        },
                        new TableCellModel
                        {
                            Value = info.Details.Version.ToString(),
                            Tooltip = info.Details.Version.ToString()
                        },
                        new TableCellModel
                        {
                            Value = string.Join(", ", attributes)
                        }
                    };

                    return rowModel;
                },
                PageAction = ActionInfo.None,
                RefreshAction = new ActionInfo
                {
                    Action = "Index",
                    Controller = "Environment",
                    RouteValues = new RouteValueDictionary
                    {
                        { "Area", "SysAdmin" }
                    },
                    Text = _translator.GetTerm("Refresh")
                },
                ResultsOnPage = assemblies.Count(),
                ResultsPerPage = assemblies.Count(),
                ResultsPerPageOptions = null,
                TotalResults = assemblies.Count()
            };

            return table;
        }
    }
}