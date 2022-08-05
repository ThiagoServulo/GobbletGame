
# Jogo das taças russas

### Descrição e regras
Taças Russas é um jogo abstrato onde cada jogador possui 3 conjuntos de peças, cada um deles contendo 4 cilindros de tamanhos escalonados que encaixam-se (semelhante às famosas Matrioskas russas).

Seu objetivo é colocar no tabuleiro quatro de suas peças em uma linha horizontal, vertical ou diagonal. Suas peças começam fora do tabuleiro e, no seu turno, você pode colocar uma nova peça no tabuleiro ou mover uma existente para qualquer outro local. 

**Importante:** Uma peça maior sempre pode ser usada para cobrir qualquer outra menor - sua ou de seu oponente. Neste sentido ele também é um jogo de memória, afinal você precisa lembrar qual a cor que suas peças estão cobrindo antes de mover uma delas, ou corre o risco de dar a vitória ao seu adversário em uma jogada sua.

### Detalhes
Para iniciar o jogo, o usuário deve informar o número de rodadas que o jogo irá conter. O número de rodadas deve ser um número ímpar maior que zero. Vence o jogo quem ganhar a maior quantidade de rodadas.

O primeiro jogador a jogar na rodada 1 será o que escolher as peças vermelhas. Nas próximas rodadas o primeiro jogador será o que perdeu na rodada anterior.

### Detalhes técnicos
O jogo foi desenvolvido em C# com auxílio do Windows Form para criar as interfaces visuais. No seu código fonte, foram tratados vários conceitos técnicos importantes como: interfaces, herança de classes, polimorfismo, sopreposição de métodos, tratativa de excessões, delegates, structs, entre outros.

Para poder documentar o código fonte deixando-o mais compreensível e explicativo, foi usado o Doxygen. O Doxygen é uma ferramenta capaz de gerar documentações softwares personalizadas, tornando o código auto explicativo.

