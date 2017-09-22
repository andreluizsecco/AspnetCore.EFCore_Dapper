using System.Collections.Generic;

namespace AspnetCore.EFCore_Dapper.Domain.Entities
{
    public class Autor
    {
        public int ID { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Livro> Livros { get; set; }
    }
}