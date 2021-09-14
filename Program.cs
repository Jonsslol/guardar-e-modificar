using System;

namespace guardar_e_modificar
{
    class Program
    {

        public struct dados
        {
            public double preco;
            public int Prod, categoria;
            public string nome, codigo, fornecedor;
        }
        static void Main(string[] args)

        {

            int op;
            dados[] estoque = new dados[30];
            dados[] Pcliente = new dados[30];
            int num_produtos = 0;

            do
            {
                //Inicio.
                //Escolha do usuario.

                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Clear();
                Console.WriteLine( "\t\t\t === BEM-VINDO AO MERCADO SUA ESCOLHA ===\n"
                                 + "\t\t\t |                                      |\n"
                                 + "\t\t\t |           1 - CLIENTE                |\n"
                                 + "\t\t\t |           2 - FORNECEDOR             |\n"
                                 + "\t\t\t |           3 - SAIR                   |\n"
                                 + "\t\t\t |                                      |\n"
                                 + "\t\t\t === BEM-VINDO AO MERCADO SUA ESCOLHA ===\n"
                                 + "                                       ");
                Console.Write("\t\t\t Digite a opção Desejada: ");
                op = int.Parse(Console.ReadLine());
                if (op == 1)

                {
                    double guardarPreco = 0;
                    do
                    {   //Demostrar os produtos guardados apartir do cadastro

                        Console.Clear();
                        Console.WriteLine("\t\t\t   ============= CLIENTE ==============\n"
                                          + "\t\t\t |                                  |\n"
                                          + "\t\t\t |       1 - ALIMENTOS              |                  Valor Total : R$ {0:f2} \n"
                                          + "\t\t\t |       2 - HIGIENE                |\n"
                                          + "\t\t\t |       3 - LIMPEZA                |\n"
                                          + "\t\t\t |       4 - PAGAR                  |\n"
                                          + "\t\t\t |       5 - VOLTAR                 |\n"
                                          + "\t\t\t |                                  |\n"
                                          + "\t\t\t ============= CLIENTE ==============\n", guardarPreco);


                        Console.Write("\t\t\t Digite a opção Desejada: ");
                        op = int.Parse(Console.ReadLine());                       
                        int escolha = 0;
                        dados[] prodCT;

                        switch (op)
                        {
                            case 1:


                                prodCT = listarParaCliente(num_produtos, estoque, 1);
                                listar(num_produtos, listarParaCliente(num_produtos, estoque, 1));
                                Console.Write("Selecione os produtos Desejados: ");
                                escolha = int.Parse(Console.ReadLine()) - 1;
                                guardarPreco += prodCT[escolha].preco;

                                break;
                            case 2:

                                prodCT = listarParaCliente(num_produtos, estoque, 2);
                                listar(num_produtos, listarParaCliente(num_produtos, estoque, 2));
                                Console.Write("Selecione os produtos Desejados: ");
                                escolha = int.Parse(Console.ReadLine()) - 1;
                                guardarPreco += prodCT[escolha].preco;
                                break;

                            case 3:

                                prodCT = listarParaCliente(num_produtos, estoque, 3);
                                listar(num_produtos, listarParaCliente(num_produtos, estoque, 3));
                                Console.Write("Selecione os produtos Desejados: ");
                                escolha = int.Parse(Console.ReadLine()) - 1;
                                guardarPreco += prodCT[escolha].preco;
                                break;
                            case 4:
                                pagar(guardarPreco);
                                op = 5;

                                break;
                        }
                    } while (op != 5);
                    Console.WriteLine("                                       ");
                    Console.WriteLine("\t\t\t  === Pressione enter para Voltar! ===");
                    Console.ReadKey();



                }
                else if (op == 2)
                {



                    do
                    {   //Cadastro de produtos  
                       
                        Console.Clear();
                         Console.WriteLine("\t\t\t ======== AREA DO FORNECEDOR ========\n"
                                         + "\t\t\t |                                  |\n"
                                         + "\t\t\t |       1 - Cadastrar              |\n"
                                         + "\t\t\t |       2 - Excluir                |\n"
                                         + "\t\t\t |       3 - Listar                 |\n"
                                         + "\t\t\t |       4 - Alterar                |\n"
                                         + "\t\t\t |       5 - Voltar                 |\n"
                                         + "\t\t\t |                                  |\n"
                                         + "\t\t\t ======== AREA DO FORNECEDOR ========\n"
                                         + "                                       ");
                        Console.Write("\t\t\t Digite sua opção: ");
                        op = int.Parse(Console.ReadLine());
                        Validar(ref op);
                        switch (op)
                        {
                            case 1:
                                Console.WriteLine("                                       ");
                                Console.WriteLine("\t\t\t === Cadastro de fornecedor ===");
                                if (num_produtos > 30)
                                    Console.WriteLine("Estamos sem espaço!");
                                else
                                    cadastro(ref num_produtos, estoque);
                                Console.ReadKey();
                                break;
                            case 2:
                                Console.WriteLine("                                       ");
                                Console.WriteLine("\t\t\t        === Exclusão ===");
                                excluir(num_produtos, estoque);
                                Console.ReadKey();
                                break;
                            case 3:
                                Console.WriteLine("                                       ");
                                Console.WriteLine("\t\t\t         === Listagem ===");
                                listar(num_produtos, estoque);
                                Console.ReadKey();
                                break;
                            case 4:
                                Console.WriteLine("                                       ");
                                Console.WriteLine("\t\t\t         === Alteração ===");
                                alterar(num_produtos, estoque);
                                Console.ReadKey();
                                break;
                        }
                    } while (op != 5);
                    Console.WriteLine("                                       ");
                    Console.WriteLine("\t\t\t      === Pressione enter para Voltar! ===");

                }

                else if (op == 3)
                {
                    Console.WriteLine("                                       ");
                    Console.WriteLine("\t\t\t      === Pressione enter para Encerrar! ===");
                    Console.ReadKey();
                }
            } while (op != 3);
            Console.ReadKey();
        }
        static void Validar(ref int x)
        {
            while (x < 1 || x > 5)
            {
                Console.Write("\t\t\t Por favor, Redigite um número entre 1 e 5: ");
                x = int.Parse(Console.ReadLine());
            }
        }
        static void cadastro(ref int i, dados[] P) // Divisão de setores
        {
            Console.Clear();
            Console.WriteLine(           "\t\t\t  ===== CADASTRO DA CATEGORIA ======== \n"
                                       + "\t\t\t |                                    |\n"
                                       + "\t\t\t |         1 - ALIMENTOS              |\n"
                                       + "\t\t\t |         2 - HIGIENE                |\n"
                                       + "\t\t\t |         3 - LIMPEZA                |\n"
                                       + "\t\t\t |                                    |\n"
                                       + "\t\t\t  ====== CADASTRO DA CATEGORIA ======= \n"
                                       + "                                       ");
            Console.Write("\t\t\t                 Digite sua opção: ");
            P[i].categoria = int.Parse(Console.ReadLine());
            Console.Write("\t\t\t Digite o nome do Produto: ");
            P[i].nome = Console.ReadLine();
            Console.Write("\t\t\t Digite o valor do Produto: ");
            P[i].preco = double.Parse(Console.ReadLine());
            P[i].Prod = 1;
            Console.Write("\t\t\t Digite o codigo do Produto: ");
            P[i].codigo = Console.ReadLine();
            Console.Write("\t\t\t Digite o nome do Fornecedor: ");
            P[i].fornecedor = Console.ReadLine();
            i++;
        }
        static void listar(int x, dados[] P)
        {
            Console.Clear();
            if (x == 0)
                Console.WriteLine("\t\t\t          *** Nenhum produto cadastrado ***");
            else
                for (int i = 0; i < x; i++) // os produtos serão guardados e distribuinos nos seus respectivos setores.
                {
                    if (P[i].Prod == 1)// por conta da exclusão que coloca zero na situação.     
                    {
                        string Gcategoria = "";
                        if (P[i].categoria == 1)
                        {
                            Gcategoria = "Alimentação";
                        }
                        else if (P[i].categoria == 2)
                        {
                            Gcategoria = "Higiene";
                        }
                        else if (P[i].categoria == 3)
                        {
                            Gcategoria = "Limpeza";
                        }

                        Console.WriteLine("Categoria {0}", Gcategoria);
                        Console.WriteLine("\t\t\t {0} - Nome do produto: {1} | Preço: R$ {2:f2} | Codigo do Produto: {3} | Fornecedor: {4}", i + 1, P[i].nome, P[i].preco, P[i].codigo, P[i].fornecedor);

                    }
                }
        }
        static void alterar(int x, dados[] P)
        {
            string pesquisa;
            char achou;
            achou = 'N';
            Console.Write("\t\t\t Digite o nome do produto que deseja alterar: ");
            pesquisa = Console.ReadLine();
            for (int i = 0; i < x; i++)
            {
                if (pesquisa == P[i].nome && P[i].Prod == 1)
                {
                    Console.Clear();
                    Console.Write("\t\t\t Digite o novo nome: ");
                    P[i].nome = Console.ReadLine();
                    Console.Write("\t\t\t Digite o novo preço do Produto: ");
                    P[i].preco = double.Parse(Console.ReadLine());
                    Console.Write("\t\t\t Digite o novo Codigo: ");
                    P[i].codigo = Console.ReadLine();
                    Console.Write("\t\t\t Digite o novo Fornecedor: ");
                    P[i].fornecedor = Console.ReadLine();
                    Console.WriteLine("\t\t\t Alterado com Sucesso!");
                    achou = 'S';
                }
            }
            if (achou == 'N')
                Console.WriteLine("\t\t\t        *** Produto não cadastrado! ***");
        }
        static void excluir(int x, dados[] P)
        {
            string pesquisa;
            char achou;
            achou = 'N';
            Console.Write("Digite o produto que deseja excluir: ");
            pesquisa = Console.ReadLine();
            for (int i = 0; i < x; i++)
            {
                if (pesquisa == P[i].nome && P[i].Prod == 1)
                {
                    P[i].Prod = 0;
                    Console.WriteLine("\t\t\t  *** Produto excluido com Sucesso! ***");
                    achou = 'S';
                }
            }
            if (achou == 'N')
                Console.WriteLine("\t\t\t         *** Produto não Cadastrado! ***");


        }
        static dados[] listarParaCliente(int x, dados[] P, int categoria) //Criando uma variavel para guardar os produtos...
        {                                                                 //Serão mandadar para suas cases do na area do cliante... 
            dados[] Pcliente = new dados[30];                             //Com formato do listar inicial.

            if (x == 0)
                Console.WriteLine("\t\t\t          *** Nenhum produto Cadastrado ***");
            else
            {
                for (int i = 0; i < x; i++)

                {

                    if (categoria == P[i].categoria)
                    {
                        Pcliente[i] = P[i];
                    }
                    else
                    {
                        Pcliente[i].Prod = 0;
                    }

                }






            }
         
            return Pcliente;


        }
    
        static void pagar(double valorTotal)
        {
            int op;
            do
            {
                Console.Clear();
                Console.WriteLine("\t\t\t =============== PAGAMENTO ===============\n"
                                + "\t\t\t |                                       |\n"
                                + "\t\t\t |           1 - DINHEIRO                |\n"
                                + "\t\t\t |           2 - CARTÃO                  |\n"
                                + "\t\t\t |           3 - VOLTAR                  |\n"
                                + "\t\t\t |                                       |\n"
                                + "\t\t\t ============== PAGAMENTO ================\n"
                                + "                                       ");
                Console.Write("\t\t\t Digite a opção desejada: ");
                op = int.Parse(Console.ReadLine());
             

            
                
                switch(op) 
                {
                    case 1:
                        Console.Clear();
                        Console.Beep(); Console.Beep(); Console.Beep();
                        Console.WriteLine("\t\t\t PAGAMENTO REALIZADO COM SUCESSO");
                        Console.ReadKey();
                        return;
                        
                    case 2:
                        Console.Clear();
                        Console.WriteLine("\t\t\t ======== PAGAMENTO NO CARTÃO ============\n"
                                        + "\t\t\t |                                       |\n"
                                        + "\t\t\t |  1 - PAGAMENTO EM 2X - 3% DE JUROS    |\n"
                                        + "\t\t\t |  2 - PAGAMENTO EM 3X - 8% DE JUROS    |\n"
                                        + "\t\t\t |                                       |\n"
                                        + "\t\t\t ======== PAGAMENTO NO CARTÃO ============\n"
                                        + "                                       ");
                        Console.Write("\t\t\t Digite sua opção: ");

                        int J = int.Parse(Console.ReadLine());
                        if (J == 1)
                        {
                            cartao(valorTotal, 0.03);
                        } else if (J == 2){
                            cartao(valorTotal, 0.08);
                        }
                        break;

                }
            }while (op != 3);
            Console.ReadKey();

        }
            static void cartao(double guardarPreco,double juros)
            {
            Console.Clear();
            Console.Beep(); Console.Beep(); Console.Beep();
            Console.WriteLine("O valor total da sua compra é de R$ {0:f2} juros foram acrescentados devido a sua escolha de pagamento, sendo assim o valor total é de R$ {1:F2}", guardarPreco, guardarPreco + guardarPreco * juros);
        
            
            Console.ReadKey();
            }   
        
    }

}


