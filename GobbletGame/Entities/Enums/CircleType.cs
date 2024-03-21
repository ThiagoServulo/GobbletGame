namespace GobbletGame.Entities.Enums
{
    /** ************************************************************************
    * \brief Agrupa os tipos de círculos.
    * \details A enumeração CircleType agrupa os tipos de círculo que irão 
    * representar as peças. Cada tipo será responsável por determinar as
    * diferentes dimensões que a peça pode apresentar. 
    * \author Thiago Sérvulo Guimarães - thiago.servulo@sga.pucminas.br
    * \date 16/07/2022
    * \version v1.0.0
    ***************************************************************************/
    enum CircleType : int
    {
        /// \brief Menor peça do tabuleiro.
        Type1 = 1,

        /// \brief Segunda menor peça do tabuleiro.
        Type2 = 2,

        /// \brief Segunda maior peça do tabuleiro.
        Type3 = 3,

        /// \brief Maior peça do tabuleiro.
        Type4 = 4
    }
}
