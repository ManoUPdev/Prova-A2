namespace EmanuelGalindo_MariaFernandaMolinas_BancoDeDados.Models
{
    public class Folha
    {
        public int Id { get; set; }
        public decimal Valor { get; set; }
        public int Quantidade { get; set; }
        public int Mes { get; set; }
        public int Ano { get; set; }
        public int FuncionarioId { get; set; }
        public Funcionarios Funcionario { get; set; }
    }
}
