namespace pruebaTecnica1.Dtos
{
    public class ClienteDto
    {
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public bool Estado { get; set; } = true;
    }
}
