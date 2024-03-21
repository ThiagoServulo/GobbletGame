﻿using GobbletGame.Entities.Enums;
using System.Windows.Forms;

namespace GobbletGame.Entities
{
    /** ************************************************************************
    * \brief Informações sobre um jogador.
    * \details  A classe Player armazena as informações referentes ao jogador 
    * que está realizando uma movimentação de uma peça. Logo, ela contém a 
    * quantidade de vitórias que o jogador possui e o tipo de jogador (Jogador X 
    * ou Y) que ele é.
    * \author Thiago Sérvulo Guimarães - thiago.servulo@sga.pucminas.br
    * \date 13/07/2022
    * \version v1.0.0
    ***************************************************************************/
    class Player
    {
        /// \brief Quantidade de vitórias do jogador.
        public int Victories { get; private set; }

        /// \brief Tipo do jogador (Jogador X ou Y).
        public PlayerType Type { get; private set; }

        /// \brief \a label que apresenta a quantidade de vitórias do jogador.
        public Label LabelVictories { get; private set; }


        /** ************************************************************************
        * \brief Construtor da classe Player.
        * \param type Tipo de jogador (Jogador X ou Y).
        ***************************************************************************/
        public Player(PlayerType type, Label label)
        {
            this.Type = type;
            this.Victories = 0;
            this.LabelVictories = label;
        }


        /** ************************************************************************
        * \brief Adiciona uma vitória para o joador.
        * \details Função responsável por adicionar uma vitória para o jogador.
        ***************************************************************************/
        public void AddVictory()
        {
            this.Victories += 1;
        }
    }
}
