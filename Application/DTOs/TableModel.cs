using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// Describes the method signature for retrieving cells for a specific row in the table model.
    /// </summary>
    /// <param name="currentIndex">The current row index.</param>
    /// <returns>A list of table cells defining data for the row.</returns>
    /// <summary>
    /// GetTableCellsHandler operation
    /// </summary>
    public delegate RowModel GetTableCellsHandler(int currentIndex); 

    /// <summary>
    /// Represents a table
    /// </summary>
    /// <summary>
    /// TableModel
    /// </summary>
    public class TableModel
    {
        /// <summary>
        /// Initialises a TableModel with default values.
        /// </summary>
        public TableModel(bool isInternetExplorer10orLess, bool isInternetExplorer11orLess)
        {
            Columns = new List<TableColumnModel>();
            ResultsPerPageOptions = new List<int> {10, 25, 50, 100};
            ShowHeaders = true;
            AutoUpdateOnFilterChange = !isInternetExplorer10orLess;
            FormId = Guid.NewGuid().ToString();
            IsInternetExplorer10orLess = isInternetExplorer10orLess;
            IsInternetExplorer11orLess = isInternetExplorer11orLess;
            ShowPageControls = true;
        }

        /// <summary>
        /// Initialises a TableModel with default values and if the browser is mobile.
        /// </summary>
        public TableModel(bool isInternetExplorer10orLess, bool isInternetExplorer11orLess, bool isMobileDevice)
        {
            Columns = new List<TableColumnModel>();
            ResultsPerPageOptions = new List<int> { 10, 25, 50, 100 };
            ShowHeaders = true;
            AutoUpdateOnFilterChange = !isInternetExplorer10orLess;
            FormId = Guid.NewGuid().ToString();
            IsInternetExplorer10orLess = isInternetExplorer10orLess;
            IsInternetExplorer11orLess = isInternetExplorer11orLess;
            IsMobileDevice = isMobileDevice;
            ShowPageControls = true;
        }

        /// <summary>
        /// If set to true the column visibility button becomes dependent on whether there are hidden columns or not (used in conjunction with new
        /// </summary>
        /// <summary>
        /// Gets or sets NotFullWindow
        /// </summary>
        public bool NotFullWindow { get; set; }

        /// <summary>
        /// Get/Set the table ID. A table ID is required in order to use checkbox functionality
        /// </summary>
        /// <summary>
        /// Gets or sets ID
        /// </summary>
        public string ID { get; set; } = Guid.NewGuid().ToString().Replace("-", "");

        /// <summary>
        /// Get/Set the table CssClass.
        /// </summary>
        /// <summary>
        /// Gets or sets CssClass
        /// </summary>
        public string CssClass { get; set; }

        /// <summary>
        /// Get/Set a value indicating if you want to apply the Table-Layout: fixed; width: 100%; css class
        /// </summary>
        /// <summary>
        /// Gets or sets FixedLayout
        /// </summary>
        public bool FixedLayout { get; set; }

        /// <summary>
        /// Get/Set the action info that defines how to refresh the table.
        /// </summary>
        /// <summary>
        /// Gets or sets RefreshAction
        /// </summary>
        public ActionInfo RefreshAction { get; set; }

        /// <summary>
        /// Get/Set the action info that defines how to navigate between page results.
        /// </summary>
        /// <summary>
        /// Gets or sets PageAction
        /// </summary>
        public ActionInfo PageAction { get; set; }

        /// <summary>
        /// Get/Set the columns defined in this table.
        /// </summary>
        /// <summary>
        /// Gets or sets Columns
        /// </summary>
        public IList<TableColumnModel> Columns { get; set; }

        /// <summary>
        /// Get/Set the current results per page.
        /// </summary>
        /// <summary>
        /// Gets or sets ResultsPerPage
        /// </summary>
        public int ResultsPerPage { get; set; }

        /// <summary>
        /// Get/Set the text to display for the results per page selection (for defining page specific labelling, e.g. "Defects Per Page").
        /// </summary>
        /// <summary>
        /// Gets or sets ResultsPerPageText
        /// </summary>
        public string ResultsPerPageText { get; set; }

        /// <summary>
        /// Get/Set the no results per page text.  If not speicified the default "No Results" text translation will be displayed.
        /// </summary>
        /// <summary>
        /// Gets or sets NoResultsText
        /// </summary>
        public string NoResultsText { get; set; }

        /// <summary>
        /// Get/Set the total number of results (before paging) for this table; used to calculate now many page navigation links to display.
        /// </summary>
        public int TotalResults
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets MaxResults
        /// </summary>
        public int MaxResults { get; set; }

        /// <summary>
        /// Get/Set the actual number of results to display on the page; used if the page contains less than the actual results per page.
        /// </summary>
        public int ResultsOnPage
        {
            get;
            set;
        }

        /// <summary>
        /// Get/Set the current page being displayed.
        /// </summary>
        public int CurrentPage
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the total number of pages, calculated using the TotalResults and ResultsPerPage.
        /// </summary>
        public int TotalPages
        {
            get
            {
                var pages = (int) Math.Ceiling(TotalResults/(double) ResultsPerPage);
                return pages > 0 ? pages : 1;
            }
        }

        public int MinVisibleResultIndex => ((CurrentPage - 1) * ResultsPerPage) + 1;

        public int MaxVisibleResultIndex => MinVisibleResultIndex + ResultsOnPage - 1;

        public bool PreviousArrowsDisabled => CurrentPage <= 1;

        public bool NextArrowsDisabled => CurrentPage >= TotalPages;

        /// <summary>
        /// Gets or sets RenderingSecondaryPaginationControl
        /// </summary>
        public bool RenderingSecondaryPaginationControl { get; set; }

        /// <summary>
        /// Event called to build get the table cells defined for a specific row in the table.
        /// </summary>
        public GetTableCellsHandler OnGetTableCells
        {
            get;
            set;
        }

        /// <summary>
        /// Get/Set the results per page options (default is 10, 25, 50, 100)
        /// </summary>
        public List<int> ResultsPerPageOptions
        {
            get;
            set;
        }

        /// <summary>
        /// Get/Set the emails main tables style
        /// </summary>
        public string EmailTableStyle
        {
            get;
            set;
        }

        /// <summary>
        /// Get/Set the emails main tables tr style
        /// </summary>
        public string EmailTableRowStyle
        {
            get;
            set;
        }

        /// <summary>
        /// Get/Set the blocking options for the table
        /// </summary>
        public BlockingOptions BlockingOptions
        {
            get;
            set;
        }

        /// <summary>
        /// Get/Set a value indicating if the table headers are to be shown
        /// </summary>
        /// <summary>
        /// Gets or sets ShowHeaders
        /// </summary>
        public bool ShowHeaders { get; set; }

        /// <summary>
        /// Should the checkbox column be displayed
        /// </summary>
        /// <summary>
        /// Gets or sets ShowCheckboxes
        /// </summary>
        public bool ShowCheckboxes { get; set; }

        /// <summary>
        /// If checkboxes are being used gets or sets the currently selected items.
        /// </summary>
        public string SelectedIdentifiers {get;set; }

        /// <summary>
        /// The name of what is being displayed in the table, used to show the count of selected items.
        /// e.g. "Number of selected Storage Points: 2"
        /// </summary>
        public string ItemTitle {get;set; }

        /// <summary>
        /// Gets or sets CaptionPartial
        /// </summary>
        public string CaptionPartial { get; set; }

        /// <summary>
        /// Flag to determine if the table should automatically update when filter changes are made, 
        /// or if a "Search" button should appear instead
        /// </summary>
        /// <summary>
        /// Gets or sets AutoUpdateOnFilterChange
        /// </summary>
        public bool AutoUpdateOnFilterChange { get; set; }

        /// <summary>
        /// If not null will show a single field's distinct values as a series of filter logenzes along 
        /// the top of the table
        /// </summary>
        /// <summary>
        /// Gets or sets LozengeSettings
        /// </summary>
        public TableLozengeSettings LozengeSettings { get; set; }
        /// <summary>
        /// Gets or sets FormId
        /// </summary>
        public string FormId { get; set; }

        /// <summary>
        /// Gets or sets IsInternetExplorer11orLess
        /// </summary>
        public bool IsInternetExplorer11orLess { get; private set; }
        /// <summary>
        /// Gets or sets IsInternetExplorer10orLess
        /// </summary>
        public bool IsInternetExplorer10orLess { get; private set; }
        /// <summary>
        /// Gets or sets IsMobileDevice
        /// </summary>
        public bool IsMobileDevice { get; private set; }

        /// <summary>
        /// Gets or sets ShowPageControls
        /// </summary>
        public bool ShowPageControls { get; set; }
    }

    /// <summary>
    /// TableModel
    /// </summary>
    public class TableModel<T> : TableModel
    {
        public TableModel(bool isInternetExplorer10orLess, bool isInternetExplorer11orLess) 
            : base(isInternetExplorer10orLess, isInternetExplorer11orLess)
        {
        }

        public TableModel(bool isInternetExplorer10orLess, bool isInternetExplorer11orLess,bool isMobileDevice)
            : base(isInternetExplorer10orLess, isInternetExplorer11orLess, isMobileDevice)
        {
        }

        /// <summary>
        /// Gets or sets Tag
        /// </summary>
        public T Tag { get; set; }
    }

}