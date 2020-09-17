# BackendTest

O projeto foi desenvolvido no Visual Studio 2019.

A API retorna apenas os dados da busca, que pode ser especificada por meio dos seguintes parâmetros na URL:
- Name (string com todo ou parte do nome do livro)
- MinPrice (double com o preço mímino)
- MaxPrice (double com o preço máximo)
- Author (string com todo ou parte do nome do autor)
- MinPage (int com o número mínimo de páginas)
- MaxPage (int com o número máximo de páginas)
- Illustrator (string com todo ou parte do nome do ilustrador)
- Genres (string com todo ou parte do gênero do livro)
- Order (string com "asc" ou "desc", para especificar uma ordenação ascendente ou descendente por preço)
 Exemplo:
 - Livro com "the" no título e "Neuville" entre os ilustradores
 https://localhost:44314/consultaLivros?Name=the&Illustrator=Neuville
