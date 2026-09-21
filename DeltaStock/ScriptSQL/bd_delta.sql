# ==== DeltaStock ===
#Emanuel Batista da Silva (Presente)
#Gustavo Marques Costa (Presente)
#João Guilherme Guariento Oliveira (Presente)
#João Pedro Pereira da Silva Lima (Presente)
#Vinícius de Oliveira Santos (Presente)
#Otávio Henrique Nocetti Silva (Ausente)

CREATE DATABASE bd_deltastock;
USE bd_deltastock;

CREATE TABLE Usuario(
    id_usu int primary key auto_increment,
    nome_usu varchar(300),
    email_usu varchar(300),
    senha_usu varchar(300),
    telefone_usu varchar(100),
    endereco_usu varchar(300),
    tipo_usu varchar(100),
    status_usu varchar(100)
);

insert into Usuario values 
(null, 'Joao Eujacio', 'Joaoeujacio@gmail.com','joaoHAHHAHA','69 9 9999 9999', 'Casa dos patos','Vendedor', 'Ativo'),
(null, 'maria Eujacio', 'Mariaeujacio@gmail.com','MariaHAHHAHA','69 9 9999 9998', 'Casa dos frangos','Vendedor', 'Desativado'),
(null, 'Carlos Eujacio', 'Carloseujacio@gmail.com','CarlosHAHHAHA','69 9 9999 9988', 'Casa dosganços','Admin', 'Ativo'),
(null, 'Nicolas Eujacio', 'Nicolaseujacio@gmail.com','NicolasHAHHAHA','69 9 9999 9888', 'Casa das codornas','Admin', 'Ativo'),
(null, 'Matheus Eujacio', 'MatheusNeujacio@gmail.com','1234HAHHAHA','69 9 9999 8888', 'Casa dos porcos','Vendedor', 'Desativado'),
(null, 'Amanda Dias Fernandes', 'Mands@gmail.com','amanda_31','69 9 9998 8888', 'Casa dos sonhos','Vendedor', 'Ativo'),
(null, 'Joao Pedro Pereira da Silva lima', 'JoaoPereira@gmail.com','JoaoGataoapaixonado123','69 9 9988 8888', 'Casa dos sonhos','Vendedor', 'Ativo');

CREATE TABLE Categoria(
    id_cat int primary key auto_increment,
    nome_cat varchar(300),
    descricao_cat varchar(500),
    codigo_cat varchar(100),
    status_cat varchar(100),
    data_cadastro_cat date
);

insert into Categoria values (id_cat, nome_cat, descricao_cat, codigo_cat, status_cat, data_cadastro_cat),
(null,"Eletrônicos", "Produtos de informática",1, "novo", '2026-01-01'),
(null,"Decoração","Produtos de decoração",2, "novo", '2026-01-01'),
(null,"Cozinha","Para cozinha",3, "novo", '2026-01-01'),
(null,"Casa e banho","Casa e banho",4, "novo", '2026-01-01'),
(null,"Alimentos","Produtos comestiveis",5, "novo", '2026-01-01'),
(null,"Ferramentas","Ferramentas gerais",6, "novo", '2026-01-01'),
(null,"Automotiva","Peças para carro",7, "novo", '2026-01-01');

CREATE TABLE Fornecedor(
    id_forn int primary key auto_increment,
    nome_forn varchar(300),
    cnpj_forn varchar(100),
    email_forn varchar(300),
    telefone_forn varchar(100),
    endereco_forn varchar(300),
    status_forn varchar(100)
);

insert into Fornecedor values(null, 'João Eujacio Tech LTDA', '12.345.678/0001-90', 'contato@techjoaoeuj.com', '(69) 3221-4587', 'Av. Brasil, nº 1200, Centro', 'Ativo');
insert into Fornecedor values(null, 'Mega Jackson LTDA', '23.456.789/0001-81', 'vendas@jackseletronicos.com', '(69) 3421-7623', 'Rua Paraná, nº 450, Nova Brasília', 'Ativo');
insert into Fornecedor values(null, 'Roupas & Estilo Clayton', '34.567.890/0001-72', 'contato@roupasargilaton.com', '(69) 3225-1842', 'Av. Marechal Rondon, nº 780, Centro', 'Ativo');
insert into Fornecedor values(null, 'Calçados Emi LTDA', '45.678.901/0001-63', 'vendas@calcadosemi.com', '(69) 3422-9134', 'Rua São Paulo, nº 320, Jardim dos Migrantes', 'Ativo');
insert into Fornecedor values(null, 'Jefferson dos Acessórios', '56.789.012/0001-54', 'contato@jeffinhoacessorios.com', '(69) 3217-6548', 'Av. JK, nº 950, Centro', 'Ativo');
insert into Fornecedor values(null, 'Distribuidora Danilo LTDA', '67.890.123/0001-45', 'comercial@distribuidoradanilagens.com', '(69) 3423-7812', 'Rua Amazonas, nº 610, Urupá', 'Ativo');
insert into Fornecedor values(null, 'Paulo Suprimentos LTDA', '78.901.234/0001-36', 'contato@paulinsuprimentos.com', '(69) 3224-5390', 'Av. 6 de Maio, nº 275, Centro', 'Ativo');

CREATE TABLE Produto(
    id_prod int primary key auto_increment,
    codigo_prod varchar(100),
    nome_prod varchar(300),
    descricao_prod varchar(500),
    quantidade_prod int,
    custo_prod float,
    valor_venda_prod float,
    status_prod varchar(100),
    data_cadastro_prod date,
    id_cat_fk int,
    foreign key(id_cat_fk) references Categoria(id_cat),
    id_forn_fk int,
    foreign key(id_forn_fk) references Fornecedor(id_forn)
);

insert into Produto values
(null, 'PROD001', 'Teclado Mecânico', 'Teclado mecânico USB com iluminação RGB', 25, 120.00, 189.90, 'Ativo', '2026-01-05', 1, 1),
(null, 'PROD002', 'Mouse Gamer', 'Mouse gamer com 6 botões e iluminação RGB', 30, 65.00, 99.90, 'Ativo', '2026-01-06', 1, 2),
(null, 'PROD003', 'Monitor 24 Polegadas', 'Monitor LED Full HD de 24 polegadas', 15, 520.00, 699.90, 'Ativo', '2026-01-08', 1, 1),
(null, 'PROD004', 'Luminária de Mesa', 'Luminária decorativa para mesa de escritório', 20, 45.00, 79.90, 'Ativo', '2026-01-10', 2, 3),
(null, 'PROD005', 'Quadro Decorativo', 'Quadro decorativo para ambientes internos', 18, 35.00, 59.90, 'Ativo', '2026-01-12', 2, 3),
(null, 'PROD006', 'Jogo de Panelas', 'Jogo de panelas antiaderentes com 5 peças', 12, 180.00, 299.90, 'Ativo', '2026-01-15', 3, 6),
(null, 'PROD007', 'Liquidificador', 'Liquidificador doméstico com 5 velocidades', 10, 110.00, 179.90, 'Ativo', '2026-01-18', 3, 7);

CREATE TABLE Movimentacao(
    id_mov int primary key auto_increment,
    data_mov datetime,
    tipo_mov varchar(100),
    quantidade_mov int,
    saldo_anterior_mov int,
    saldo_final_mov int,
    origem_mov varchar(300),
    id_documento_mov varchar(300),
    motivo_mov varchar(500),
    id_prod_fk int,
    foreign key(id_prod_fk) references Produto(id_prod),
    id_usu_fk int,
    foreign key(id_usu_fk) references Usuario(id_usu)
);

insert into Movimentacao values(null, '2026-08-01 08:30:00', 'ENTRADA', 50, 100, 150, 'Compra', 'NF001', null, 1, 1);
insert into Movimentacao values(null, '2026-08-01 10:15:00', 'SAIDA', 10, 150, 140, 'Venda', 'VENDA001', null, 1, 2);
insert into Movimentacao values(null, '2026-08-02 09:20:00', 'ENTRADA', 30, 200, 230, 'Reposição', 'NF002', null, 2, 1);
insert into Movimentacao values(null, '2026-08-02 14:40:00', 'AJUSTE+', 5, 230, 235, 'Ajuste de estoque', null, 'Produto encontrado durante conferência', 2, 2);
insert into Movimentacao values(null, '2026-08-03 11:10:00', 'SAIDA', 8, 235, 227, 'Venda', 'VENDA002', null, 2, 1);
insert into Movimentacao values(null, '2026-08-04 13:25:00', 'AJUSTE-', 3, 150, 147, 'Ajuste de estoque', null, 'Diferença encontrada na contagem', 3, 2);
insert into Movimentacao values(null, '2026-08-05 16:50:00', 'PERDA', 2, 147, 145, 'Descarte', null, 'Produto danificado', 3, 1);

CREATE TABLE Venda(
    id_ven int primary key auto_increment,
    data_ven datetime,
    valor_total_ven float,
    status_ven varchar(100),
    id_usu_fk int,
    foreign key(id_usu_fk) references Usuario(id_usu)
);

INSERT INTO Venda (id_ven, data_ven, valor_total_ven, status_ven, id_usu_fk) VALUES
(null, '2026-01-15 10:30:00', 189.90, 'Concluída', 1),
(null, '2026-02-08 14:20:00', 349.90, 'Concluída', 2),
(null, '2026-03-21 09:15:00', 79.90, 'Pendente', 1),
(null, '2026-04-12 16:40:00', 529.90, 'Concluída', 3),
(null, '2026-05-27 11:05:00', 249.90, 'Cancelada', 2),
(null, '2026-06-06 13:50:00', 699.90, 'Concluída', 4),
(null, '2026-08-03 15:25:00', 419.90, 'Pendente', 3);

CREATE TABLE ItemVenda(
    id_item int primary key auto_increment,
    quantidade_item int,
    valor_unitario_item float,
    subtotal_item float,
    id_ven_fk int,
    foreign key(id_ven_fk) references Venda(id_ven),
    id_prod_fk int,
    foreign key(id_prod_fk) references Produto(id_prod)
);

insert into ItemVenda values(null, 2, 89.90, 179.80, 1, 1);
insert into ItemVenda values(null, 1, 1869.00, 1869.00, 1, 2);
insert into ItemVenda values(null, 3, 49.90, 149.70, 2, 3);
insert into ItemVenda values(null, 2, 129.90, 259.80, 2, 4);
insert into ItemVenda values(null, 1, 299.90, 299.90, 3, 5);
insert into ItemVenda values(null, 4, 39.90, 159.60, 3, 6);
insert into ItemVenda values(null, 2, 79.90, 159.80, 4, 7);
