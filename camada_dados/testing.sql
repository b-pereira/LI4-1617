USE MM2;
GO
SELECT * FROM dbo.Cliente_avalia_Estabelecimento INNER JOIN dbo.Cliente_critica_iguaria ON dbo.Cliente_avalia_Estabelecimento.Estabelecimento = dbo.Cliente_critica_iguaria.Estabelecimento;


SELECT * FROM dbo.Cliente_avalia_Estabelecimento;

SELECT * FROM dbo.Cliente_critica_iguaria;

SELECT * FROM dbo.Cliente;

SELECT * FROM dbo.Utilizador;

UPDATE dbo.Utilizador SET tipo = 0 WHERE email = 'ola@mail.pt';

SELECT * FROM dbo.Iguaria;

SELECT * FROM dbo.HorarioEstabelecimento;

SELECT * FROM dbo.Estabelecimento;

SELECT * FROM dbo.SelecaoIguaria;
SELECT * FROM dbo.SelecaoEstabelecimento;

SELECT COUNT(*) FROM dbo.SelecaoIguaria WHERE Cliente = 1 AND Estabelecimento = 2 AND Iguaria = 1;

SELECT * FROM dbo.Cliente WHERE id_cliente = 1;

SELECT * FROM dbo.Utilizador;

SELECT * FROM dbo.Cliente_seleciona_Estabelecimento;
SELECT * FROM dbo.Cliente_seleciona_iguaria;

SELECT * FROM dbo.Cliente_critica_Iguaria;

DELETE FROM dbo.SelecaoIguaria WHERE id_visualizacao = 0;

DELETE FROM dbo.SelecaoEstabelecimento WHERE id_selecao = 0;

SELECT * FROM dbo.Cliente_seleciona_iguaria WHERE Cliente = 1 AND Iguaria = 2 AND Estabelecimento = 1;


SELECT * FROM dbo.Cliente_critica_Iguaria;

SELECT * FROM dbo.Cliente_avalia_Estabelecimento;




SELECT nome_iguaria, visual_iguaria, rating_medio_iguaria, nome_estabelecimento, visual_estabelecimento, rating_medio_estabelecimento FROM dbo.Iguaria INNER JOIN dbo.Estabelecimento ON id_estabelecimento = Estabelecimento WHERE nome_iguaria LIKE '%Beef%' ORDER BY  visual_estabelecimento ASC;


SELECT * FROM dbo.Iguaria WHERE Estabelecimento = 3;

DELETE FROM dbo.Iguaria WHERE Estabelecimento = 3;

DELETE FROM dbo.Estabelecimento WHERE id_estabelecimento = 3;


SELECT * FROM dbo.Iguaria WHERE nome_iguaria LIKE '%Bife%';