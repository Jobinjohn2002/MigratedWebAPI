using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public enum WidgetLayout
    {
        Single = 1,
        Double = 2,
        Tripple = 3
    }

    /// <summary>
    /// WidgetDefinition
    /// </summary>
    public class WidgetDefinition
    {
        private string _id = Guid.NewGuid().ToString();

        /// <summary>
        /// Gets or sets Active
        /// </summary>
        public bool Active { get; set; }
        /// <summary>
        /// Gets or sets ID
        /// </summary>
        public string ID { get { return _id; } }
        /// <summary>
        /// Gets or sets Options
        /// </summary>
        public Dictionary<string, object> Options { get; set; }
        /// <summary>
        /// Gets or sets RefreshInterval
        /// </summary>
        public int RefreshInterval { get; set; }
        /// <summary>
        /// Gets or sets StoredProcedureName
        /// </summary>
        public string StoredProcedureName { get; set; }
        /// <summary>
        /// Gets or sets TranslationEntity
        /// </summary>
        public string TranslationEntity { get; set; }
        /// <summary>
        /// Gets or sets TranslationGroup
        /// </summary>
        public string TranslationGroup { get; set; }
        /// <summary>
        /// Gets or sets TranslationSection
        /// </summary>
        public string TranslationSection { get; set; }
    }

    /// <summary>
    /// UserWidgetDefinition
    /// </summary>
    public class UserWidgetDefinition : WidgetDefinition
    {
        /// <summary>
        /// Gets or sets Size
        /// </summary>
        public WidgetLayout Size { get; set; }
    }

    /// <summary>
    /// UserChartWidgetDefinition
    /// </summary>
    public class UserChartWidgetDefinition<T> : UserWidgetDefinition
    {
        /// <summary>
        /// Gets or sets SeriesStyleOverrides
        /// </summary>
        public Dictionary<string, object> SeriesStyleOverrides { get; set; }
        /// <summary>
        /// Gets or sets Type
        /// </summary>
        public T Type { get; set; }
    }

    public enum KnownDashboardWidget
    {
        Unknown = 0,
        ServiceReport_IntakeRate = 1,
        ServiceReport_ClassificationBreakdown = 2,
        ServiceReport_SeverityBreakdown = 3,
        ServiceReport_StatusBreakdown = 4,
        Turnaround_DefectRate = 5,
        Turnaround_DeliveryOnTimeRate = 6,
        ContainerInstance_UsageRate = 7,
        ServiceReport_ResponsibilityBreakdown = 8,
        ServiceReport_SynergyResponsibilityBreakdown = 9,
        CustomerDefect_Outstanding = 10
    }

    public sealed class WidgetModel
    {
        /// <summary>
        /// Gets or sets ID
        /// </summary>
        public KnownDashboardWidget ID { get; set; }
        /// <summary>
        /// Gets or sets Definition
        /// </summary>
        public UserWidgetDefinition Definition { get; set; }
        /// <summary>
        /// Gets or sets Debug
        /// </summary>
        public DebugInfo Debug { get; internal set; }
        /// <summary>
        /// Gets or sets Model
        /// </summary>
        public WidgetViewModel Model { get; set; }
        /// <summary>
        /// Gets or sets GetData
        /// </summary>
        public Action<WidgetModel> GetData { get; set; }
    }

    [System.AttributeUsage(AttributeTargets.Class)]
    /// <summary>
    /// WidgetViewAttribute
    /// </summary>
    public class WidgetViewAttribute : Attribute
    {
        public WidgetViewAttribute(string view) 
        {
            View = view;
        }

        /// <summary>
        /// Gets or sets View
        /// </summary>
        public string View { get; set; }
    }

    public abstract class WidgetViewModel
    {
        /// <summary>
        /// Gets or sets Action
        /// </summary>
        public string Action { get; set; }

        /// <summary>
        /// Gets or sets Definition
        /// </summary>
        public UserWidgetDefinition Definition { get; set; }

        public string View
        {
            get
            {
                var att = GetType().GetCustomAttributes(typeof(WidgetViewAttribute), true).FirstOrDefault() as WidgetViewAttribute;

                if (att != null)
                {
                    return att.View;
                }

                return default(string);
            }
        }
    }

    /// <summary>
    /// DashboardModel
    /// </summary>
    public class DashboardModel
    {
        public DashboardModel()
        {
            Widgets = new List<WidgetModel>();
        }

        /// <summary>
        /// Gets or sets ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// Gets or sets Title
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Gets or sets Widgets
        /// </summary>
        public List<WidgetModel> Widgets { get; set; }
        /// <summary>
        /// Gets or sets Debug
        /// </summary>
        public DebugInfo Debug { get; set; }

        /// <summary>
        /// HookupDebugToWidgets operation
        /// </summary>
        public void HookupDebugToWidgets()
        {
            if (Widgets != null)
                Widgets.ForEach(w => w.Debug = Debug);
        }
    }

    /// <summary>
    /// DashboardState
    /// </summary>
    public class DashboardState
    {
        /// <summary>
        /// Gets or sets UICulture
        /// </summary>
        public CultureInfo UICulture { get; set; }
    }

    /// <summary>
    /// ChartStyling
    /// </summary>
    public class ChartStyling
    {

        /// <summary>
        /// GetSeriesColor operation
        /// </summary>
        public static string GetSeriesColor(int index, bool alpha = true)
        {
            return GetSeriesColor(index, alpha ? (float?)1f : null);
        }

        /// <summary>
        /// GetMultiSeriesColor operation
        /// </summary>
        public static string GetMultiSeriesColor(int index, bool alpha = true)
        {
            return GetSeriesColor(index, alpha ? (float?)0.5f : null);
        }

        static string GetSeriesColor(int index, float? alpha)
        {
            string colorString = "#FFF";

            int i = index / Colors.Length;
            int colorIndex = index - (Colors.Length * i);
            float correctionFactor = 0;

            if (i > 0)
            {
                int adjust = (i < 10 ? 0 - i : i - 10);

                correctionFactor = adjust / 10f;
            }

            Color seriesColor = ChangeColorBrightness(System.Drawing.ColorTranslator.FromHtml(ChartStyling.Colors[colorIndex]), correctionFactor);

            System.Diagnostics.Debug.WriteLine(correctionFactor);

            colorString =
                (alpha == null ? "rgb({0}, {1}, {2})" : "rgba({0}, {1}, {2}, {3})")
                .FormatWith(seriesColor.R, seriesColor.G, seriesColor.B, alpha == null ? 0 : alpha.Value);

            return colorString;
        }

        static string[] Colors = new string[] { 
        "#A3D4FE",
        "#B0BBC3",
        "#2FA0FF",
        "#A2A4A5",
        "#717D87",
        "#616161",
        "#739AB9",
        "#4798D1",
        "#95B2C7",
        "#346D97",
        "#ADD4E2",
        "#1594CB",
        "#65AFC3",
        "#68B3CD"};

        /// <summary>
        /// Gets or sets PostiveChangeColor
        /// </summary>
        public static string PostiveChangeColor { get { return "#AFBC3F"; } }

        /// <summary>
        /// Gets or sets NegativeChangeColor
        /// </summary>
        public static string NegativeChangeColor { get { return "#F7464A"; } }

        /// <summary>
        /// Creates color with corrected brightness.
        /// </summary>
        /// <param name="color">Color to correct.</param>
        /// <param name="correctionFactor">The brightness correction factor. Must be between -1 and 1. 
        /// Negative values produce darker colors.</param>
        /// <returns>
        /// Corrected <see cref="Color"/> structure.
        /// </returns>
        /// <summary>
        /// ChangeColorBrightness operation
        /// </summary>
        public static Color ChangeColorBrightness(Color color, float correctionFactor)
        {
            float red = (float)color.R;
            float green = (float)color.G;
            float blue = (float)color.B;

            if (correctionFactor < 0)
            {
                correctionFactor = 1 + correctionFactor;
                red *= correctionFactor;
                green *= correctionFactor;
                blue *= correctionFactor;
            }
            else
            {
                red = (255 - red) * correctionFactor + red;
                green = (255 - green) * correctionFactor + green;
                blue = (255 - blue) * correctionFactor + blue;
            }

            return Color.FromArgb(color.A, (int)red, (int)green, (int)blue);
        }
    }

    /// <summary>
    /// SingleSeriesData
    /// </summary>
    public class SingleSeriesData
    {
        /// <summary>
        /// Gets or sets color
        /// </summary>
        public string color { get; set; }
        /// <summary>
        /// Gets or sets label
        /// </summary>
        public string label { get; set; }
        /// <summary>
        /// Gets or sets labelAlign
        /// </summary>
        public string labelAlign { get; set; }
        /// <summary>
        /// Gets or sets labelColor
        /// </summary>
        public string labelColor { get; set; }
        /// <summary>
        /// Gets or sets labelFontSize
        /// </summary>
        public string labelFontSize { get; set; }
        /// <summary>
        /// Gets or sets value
        /// </summary>
        public decimal value { get; set; }
    }

    /// <summary>
    /// MultiSeriesData
    /// </summary>
    public class MultiSeriesData
    {
        /// <summary>
        /// Gets or sets data
        /// </summary>
        public List<decimal> data { get; set; }
        /// <summary>
        /// Gets or sets fillColor
        /// </summary>
        public string fillColor { get; set; }
        /// <summary>
        /// Gets or sets pointColor
        /// </summary>
        public string pointColor { get; set; }
        /// <summary>
        /// Gets or sets pointStrokeColor
        /// </summary>
        public string pointStrokeColor { get; set; }
        /// <summary>
        /// Gets or sets strokeColor
        /// </summary>
        public string strokeColor { get; set; }
    }

    public enum SingleSeriesChartType { Doughnut = 1, PolarArea = 2, Pie = 3 }
    public enum MultiSeriesChartType { Bar = 1, Line = 2, Radar = 3 }

    public abstract class ChartWidgetModel<T> : WidgetViewModel
    {
        /// <summary>
        /// Gets or sets Type
        /// </summary>
        public T Type { get; set; }
    }

    [WidgetView("SingleSeriesChartWidget")]
    /// <summary>
    /// SingleSeriesChartWidgetModel
    /// </summary>
    public class SingleSeriesChartWidgetModel : ChartWidgetModel<SingleSeriesChartType>
    {
        private List<SingleSeriesData> _data = new List<SingleSeriesData>();

        public List<SingleSeriesData> data
        {
            get { return this._data; }
            set { this._data = value; }
        }
    }

    [WidgetView("MultiSeriesChartWidget")]
    /// <summary>
    /// MultiSeriesChartWidgetModel
    /// </summary>
    public class MultiSeriesChartWidgetModel : ChartWidgetModel<MultiSeriesChartType>
    {
        public MultiSeriesChartWidgetModel()
            : base()
        {
            this.datasets = new List<MultiSeriesData>();
            this.labels = new List<string>();
        }

        /// <summary>
        /// Gets or sets datasets
        /// </summary>
        public List<MultiSeriesData> datasets { get; set; }
        /// <summary>
        /// Gets or sets labels
        /// </summary>
        public List<string> labels { get; set; }
    }
}