namespace ProyectoSeminarioCic

{
    internal class charlistas
    {
        public string nombre { get; set; }
        public string apellido { get; set; }

        public override string ToString()
        {
            return this.nombre+" "+this.apellido;
        }
    }
}