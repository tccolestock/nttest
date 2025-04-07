#region Using declarations
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Xml.Serialization;
using NinjaTrader.Cbi;
using NinjaTrader.Gui;
using NinjaTrader.Gui.Chart;
using NinjaTrader.Gui.SuperDom;
using NinjaTrader.Gui.Tools;
using NinjaTrader.Data;
using NinjaTrader.NinjaScript;
using NinjaTrader.Core.FloatingPoint;
using NinjaTrader.NinjaScript.DrawingTools;
#endregion

//This namespace holds Indicators in this folder and is required. Do not change it. 
namespace NinjaTrader.NinjaScript.Indicators.nttest
{
	public class nttest1 : Indicator
	{
		protected override void OnStateChange()
		{
			if (State == State.SetDefaults)
			{
				Description									= @"Simple holder to test git";
				Name										= "nttest1";
				Calculate									= Calculate.OnBarClose;
				IsOverlay									= true;
				DisplayInDataBox							= true;
				DrawOnPricePanel							= true;
				DrawHorizontalGridLines						= true;
				DrawVerticalGridLines						= true;
				PaintPriceMarkers							= true;
				ScaleJustification							= NinjaTrader.Gui.Chart.ScaleJustification.Right;
				//Disable this property if your indicator requires custom values that cumulate with each new market data event. 
				//See Help Guide for additional information.
				IsSuspendedWhileInactive					= true;
				OffsetValue					= 1;
				AddPlot(Brushes.Orange, "TestPlot1");
			}
			else if (State == State.Configure)
			{
			}
		}

		protected override void OnBarUpdate()
		{
			//Add your custom indicator logic here.
			TestPlot1[0] = Close[0] + OffsetValue;
		}

		#region Properties
		[NinjaScriptProperty]
		[Range(1, int.MaxValue)]
		[Display(Name="OffsetValue", Description="offset plot price ", Order=1, GroupName="Parameters")]
		public int OffsetValue
		{ get; set; }

		[Browsable(false)]
		[XmlIgnore]
		public Series<double> TestPlot1
		{
			get { return Values[0]; }
		}
		#endregion

	}
}

#region NinjaScript generated code. Neither change nor remove.

namespace NinjaTrader.NinjaScript.Indicators
{
	public partial class Indicator : NinjaTrader.Gui.NinjaScript.IndicatorRenderBase
	{
		private nttest.nttest1[] cachenttest1;
		public nttest.nttest1 nttest1(int offsetValue)
		{
			return nttest1(Input, offsetValue);
		}

		public nttest.nttest1 nttest1(ISeries<double> input, int offsetValue)
		{
			if (cachenttest1 != null)
				for (int idx = 0; idx < cachenttest1.Length; idx++)
					if (cachenttest1[idx] != null && cachenttest1[idx].OffsetValue == offsetValue && cachenttest1[idx].EqualsInput(input))
						return cachenttest1[idx];
			return CacheIndicator<nttest.nttest1>(new nttest.nttest1(){ OffsetValue = offsetValue }, input, ref cachenttest1);
		}
	}
}

namespace NinjaTrader.NinjaScript.MarketAnalyzerColumns
{
	public partial class MarketAnalyzerColumn : MarketAnalyzerColumnBase
	{
		public Indicators.nttest.nttest1 nttest1(int offsetValue)
		{
			return indicator.nttest1(Input, offsetValue);
		}

		public Indicators.nttest.nttest1 nttest1(ISeries<double> input , int offsetValue)
		{
			return indicator.nttest1(input, offsetValue);
		}
	}
}

namespace NinjaTrader.NinjaScript.Strategies
{
	public partial class Strategy : NinjaTrader.Gui.NinjaScript.StrategyRenderBase
	{
		public Indicators.nttest.nttest1 nttest1(int offsetValue)
		{
			return indicator.nttest1(Input, offsetValue);
		}

		public Indicators.nttest.nttest1 nttest1(ISeries<double> input , int offsetValue)
		{
			return indicator.nttest1(input, offsetValue);
		}
	}
}

#endregion
