using System;
using DevExpress.XtraPivotGrid;

namespace Windows.Core.Helpers
{
    public static class PivotGridHelper
    {
        public static decimal? GetWeightedValue(PivotDrillDownDataSource ds, PivotGridField fieldPrc,
            PivotGridField fieldQty)
        {
            decimal vpGewichtet = 0m;
            decimal totalQty = 0m;
            decimal? result = null;

            foreach (PivotDrillDownDataRow dr in ds)
            {
                if (dr[fieldPrc] != null && dr[fieldQty] != null)
                {
                    vpGewichtet += Convert.ToDecimal(dr[fieldPrc])*Convert.ToInt32(dr[fieldQty]);
                    totalQty += Convert.ToInt32(dr[fieldQty]);
                }
            }

            if (totalQty > 0)
                result = vpGewichtet/totalQty;

            return result;
        }

        public static decimal? GetWeightedTdMValue(PivotDrillDownDataSource ds, PivotGridField fieldTdM,
            PivotGridField fieldPrc, PivotGridField fieldQty)
        {
            decimal tdMGewichtet = 0m;
            decimal totalUmsatz = 0m;
            decimal? result = null;

            foreach (PivotDrillDownDataRow dr in ds)
            {
                if (dr[fieldTdM] != null && dr[fieldPrc] != null && dr[fieldQty] != null)
                {
                    tdMGewichtet += Convert.ToDecimal(dr[fieldTdM])*Convert.ToDecimal(dr[fieldPrc])*
                                    Convert.ToInt32(dr[fieldQty]);
                    totalUmsatz += Convert.ToDecimal(dr[fieldPrc])*Convert.ToInt32(dr[fieldQty]);
                }
            }

            if (totalUmsatz > 0)
                result = tdMGewichtet/totalUmsatz;

            return result;
        }

        public static void SetRowFieldsInvisible(PivotGridControl ctrl)
        {
            foreach (PivotGridField f in ctrl.Fields)
            {
                if (f.Area == PivotArea.RowArea)
                {
                    f.Visible = false;
                }
            }
        }

        public static void SetColumnFieldsInvisible(PivotGridControl ctrl)
        {
            foreach (PivotGridField f in ctrl.Fields)
            {
                if (f.Area == PivotArea.ColumnArea)
                {
                    f.Visible = false;
                }
            }
        }

        public static void SetDataFieldsInvisible(PivotGridControl ctrl)
        {
            foreach (PivotGridField f in ctrl.Fields)
            {
                if (f.Area == PivotArea.DataArea)
                {
                    f.Visible = false;
                }
            }
        }

        public static void DefineColumnAreaFields(PivotGridField[] pgfa)
        {
            int index = 0;
            foreach (PivotGridField pgf in pgfa)
            {
                pgf.SetAreaPosition(PivotArea.ColumnArea, index);
                index++;
            }
        }

        public static void DefineRowAreaFields(PivotGridField[] pgfa)
        {
            int index = 0;
            foreach (PivotGridField pgf in pgfa)
            {
                pgf.SetAreaPosition(PivotArea.RowArea, index);
                index++;
            }
        }

        public static void DefineDataAreaFields(PivotGridField[] pgfa)
        {
            int index = 0;
            foreach (PivotGridField pgf in pgfa)
            {
                pgf.SetAreaPosition(PivotArea.DataArea, index);
                index++;
            }
        }
    }
}