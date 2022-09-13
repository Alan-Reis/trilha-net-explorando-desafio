using System.Globalization;
using System.Text;
using DesafioProjetoHospedagem.Models;

Console.OutputEncoding = Encoding.UTF8;

// Cria a suíte
Console.Write("Digite a capacidade da suíte disponível: ");
int capacidade = int.Parse(Console.ReadLine());
Suite suite = new Suite(tipoSuite: "Premium", capacidade: capacidade, valorDiaria: 30);
Console.WriteLine("--------------------------\r\n");


// Cria os modelos de hóspedes e cadastra na lista de hóspedes
List<Pessoa> hospedes = new List<Pessoa>();
Pessoa pessoa = new Pessoa();

int cadastrar = 1;
do {
Console.Write("Digite o nome do hóspede: ");
pessoa = new Pessoa(Console.ReadLine());
hospedes.Add(pessoa);

Console.WriteLine($"Hóspede {pessoa.Nome} cadastrado na {suite.TipoSuite} \r\n".ToUpper());
Console.WriteLine("--------------------------\r\n");
Console.WriteLine("Deseja cadastrar novo hóspede ?");
Console.WriteLine("0 - Não");
Console.WriteLine("1 - Sim\r\n");
Console.Write("Digite aqui: ");
cadastrar = int.Parse(Console.ReadLine());
}
while(cadastrar == 1);
Console.WriteLine("--------------------------\r\n");

// Cria uma nova reserva, passando a suíte e os hóspedes
Console.Write($"Quantidade de diária: ");
Reserva reserva = new Reserva(diasReservados: int.Parse(Console.ReadLine()));
reserva.CadastrarSuite(suite);
reserva.CadastrarHospedes(hospedes);

// Exibe a quantidade de hóspedes e o valor da diária
Console.WriteLine("--------------------------\r\n");
Console.Write($"Relatório final\r\n".ToUpper());
Console.WriteLine($"Total de Hóspedes: {reserva.ObterQuantidadeHospedes()}".ToUpper());
Console.WriteLine($"Total estadia: {reserva.CalcularValorDiaria().ToString("C", CultureInfo.CurrentCulture)}".ToUpper());
