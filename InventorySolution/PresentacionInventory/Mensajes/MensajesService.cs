namespace PresentacionInventory
{
    using System.Windows.Forms;
    using PresentacionInventory.Mensajes.FormsMensajes;

    public class MensajesService
    {
        public static void InputBox(string titulo, string txt_btn1,
                                    string txt_btn2, string texto_default, 
                                    out DialogResult result, out string mensaje)
        {
            FrmInputBox FrmInputBox = new FrmInputBox
            {
                StartPosition = FormStartPosition.CenterScreen,
                Titulo = titulo,
                Texto_boton1 = txt_btn1,
                Texto_boton2 = txt_btn2,
                TopLevel = true,
                TopMost = true,
                Texto_default = texto_default,
            };
            FrmInputBox.ShowDialog();
            result = FrmInputBox.DialogResult;
            mensaje = FrmInputBox.Mensaje;
        }

        public static void InputBox(string titulo, string txt_btn1,
                                    string txt_btn2, out DialogResult result, out string mensaje)
        {
            FrmInputBox FrmInputBox = new FrmInputBox
            {
                StartPosition = FormStartPosition.CenterScreen,
                Titulo = titulo,
                Texto_boton1 = txt_btn1,
                Texto_boton2 = txt_btn2,
                TopLevel = true,
                TopMost = true
            };
            FrmInputBox.ShowDialog();
            result = FrmInputBox.DialogResult;
            mensaje = FrmInputBox.Mensaje;
        }

        public static void MensajePregunta(string pregunta, string txt_btn1,
                                            string txt_btn2, out DialogResult result)
        {
            FrmMensajePregunta FrmMensajePregunta = new FrmMensajePregunta
            {
                StartPosition = FormStartPosition.CenterScreen,
                Pregunta = pregunta,
                Boton1 = txt_btn1,
                Boton2 = txt_btn2,
                TopLevel = true,
                TopMost = true
            };
            FrmMensajePregunta.ShowDialog();
            result = FrmMensajePregunta.DialogResult;
        }

        public static void MensajeInformacion(string informacion, string texto_boton = "Entendido")
        {
            FrmMensajeInformacion FrmMensajeInformacion = new FrmMensajeInformacion
            {
                StartPosition = FormStartPosition.CenterScreen,
                Informacion = informacion,
                TextoBoton = texto_boton
            };
            FrmMensajeInformacion.ShowDialog();
        }

        public static void MensajeOk(string mensaje, string texto_boton = "Entendido")
        {
            FrmMensajeOk FrmMensajeOk = new FrmMensajeOk
            {
                TopMost = true,
                Mensaje = mensaje,
                StartPosition = FormStartPosition.CenterScreen
            };
            FrmMensajeOk.ShowDialog();
        }

       public static void MensajeErrorCompleto(string formulario_error, string metodo_error,
            string informacion_error, string detalle_error)
        {
            FrmMensajeErrorCompleto FrmMensajeError = new FrmMensajeErrorCompleto
            {
                StartPosition = FormStartPosition.CenterScreen,
                FormularioError = formulario_error,
                MetodoError = metodo_error,
                InformacionCorta = informacion_error,
                DetalleInformacion = detalle_error
            };
            FrmMensajeError.ShowDialog();
        }

    }
}
