namespace EntidadesInventory.Models
{
    using EntidadesInventory.Helpers;
    using System;
    using System.Data;

    public class Turnos : MainViewModel
    {
        public Turnos()
        {

        }

        public Turnos(DataRow row)
        {
            try
            {
                this.Id_turno = Convert.ToInt32(row["Id_turno"]);
                this.Fecha_inicio_turno = Convert.ToDateTime(row["Fecha_turno"]);
                this.Hora_inicio_turno = TimeSpanConvert.StringToTimeSpan(row["Hora_inicio_turno"].ToString());
                this.Fecha_fin_turno = Convert.ToDateTime(row["Fecha_turno"]);
                this.Hora_fin_turno = TimeSpanConvert.StringToTimeSpan(row["Hora_fin_turno"].ToString());
                this.Valor_inicial = Convert.ToDecimal(row["Valor_inicial"]);
                this.Total_ingresos = Convert.ToDecimal(row["Total_ingresos"]);
                this.Total_egresos = Convert.ToDecimal(row["Total_egresos"]);
                this.Total_ventas = Convert.ToDecimal(row["Total_ventas"]);
                this.Total_nomina = Convert.ToDecimal(row["Total_nomina"]);
                this.Total_turno = Convert.ToDecimal(row["Total_turno"]);
                this.Estado_turno = Convert.ToString(row["Estado_turno"]);
            }
            catch (Exception ex)
            {
                 GetErrorModel(ex.Message, this);
            }
        }

        public int Id_turno { get; set; }

        public DateTime Fecha_inicio_turno { get; set; }

        public TimeSpan Hora_inicio_turno { get; set; }

        public DateTime Fecha_fin_turno { get; set; }

        public TimeSpan Hora_fin_turno { get; set; }

        public decimal Valor_inicial { get; set; }

        public decimal Total_ingresos { get; set; }

        public decimal Total_egresos { get; set; }

        public decimal Total_ventas { get; set; }

        public decimal Total_nomina { get; set; }

        public decimal Total_turno { get; set; }

        public string Estado_turno { get; set; }

        
    }
}
