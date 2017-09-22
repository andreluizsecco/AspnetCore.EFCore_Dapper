namespace AspnetCore.EFCore_Dapper.Domain.Entities
{
    public class Livro
    {
        public int ID { get; set; }
        public int AutorID { get; set; }
        public string Titulo { get; set; }
        public int AnoPublicacao { get; set; }

        public virtual Autor Autor { get; set; }
    }
}