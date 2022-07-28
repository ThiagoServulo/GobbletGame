using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using JogoDasTacasRussas.Entities.Enums;

namespace JogoDasTacasRussas.Entities
{
    /** ************************************************************************
    * \brief Informações sobre o campo.
    * \details A classe Field armazena as informações referentes aos campos
    * que o tabuleiro irá conter.  
    * \author Thiago Sérvulo Guimarães - thiago.servulo@sga.pucminas.br
    * \date 20/07/2022
    * \version v1.0
    ***************************************************************************/
    class Field
    {
        /// \brief \a pictureBox referente a este campo.
        public PictureBox FieldPictureBox { get; private set; }
        
        /// \brief Pilha que recebe os círculos adicionados neste campo.
        public Stack<Circle> StackCircles { get; private set; }


        /** ************************************************************************
        * \brief Construtor da classe Field.
        * \param pictureBox \a pictureBox referente a este campo.
        ***************************************************************************/
        public Field(PictureBox pictureBox)
        {
            this.FieldPictureBox = pictureBox;
            this.StackCircles = new Stack<Circle>();
            this.StackCircles.Clear();
        }


        /** ************************************************************************
        * \brief Adiciona um círculo no campo.
        * \details Função responsável por adicionar um círculo ao topo da pilha 
        * referente a este campo.
        * \param circle Círculo que será adicionado neste campo.
        ***************************************************************************/
        public void AddCircle(Circle circle)
        {
            // Adiciona o círculo ao topo da pilha
            this.StackCircles.Push(circle);

            // Desenha o novo círculo que se encontra no topo da pilha
            this.DrawCircle(circle);
        }


        /** ************************************************************************
        * \brief Remove um círculo do campo.
        * \details Função responsável por remover o círculo que está no topo da
        * pilha deste campo e retorná-lo.
        * \return Valor do tipo Circle, que corresponde ao círculo que estava no
        * topo da pilha deste campo.
        ***************************************************************************/
        public Circle PopCircle()
        {
            // Remove o círculo que está no topo da pilha
            Circle circle = this.StackCircles.Pop();

            // Desenha o novo círculo que se encontra no topo da pilha
            this.DrawCircle(this.GetLast());
            return circle;
        }


        /** ************************************************************************
        * \brief Troca a cor do círculo.
        * \details Função responsável por trocar a cor do círculo que se encontra
        * neste campo.
        ***************************************************************************/
        public void ChangeCircleColor()
        {
            // Pega o círculo que está no topo da pilha
            Circle circle = this.GetLast();

            // Se o círculo não for null, sua cor será alterada
            if (circle != null)
            {
                this.StackCircles.Pop();
                circle.Color.ChangeColor();
                this.AddCircle(circle);
            }
        }


        /** ************************************************************************
        * \brief Pega as informações do círculo atual de um campo.
        * \details Função responsável por pegar o círculo que se encontra no topo 
        * da pilha deste campo e retornar suas informações.
        * \return Valor do tipo Circle, que corresponde ao círculo que estava no
        * topo da pilha deste campo.
        ***************************************************************************/
        public Circle GetLast()
        {
            if (this.StackCircles.Count == 0)
            {
                return null;
            }
            return this.StackCircles.Peek();
        }


        /** ************************************************************************
        * \brief Limpa a pilha de círculos.
        * \details Função responsável por limpar a pilha de círculos deste campo.
        ***************************************************************************/
        public void Clear()
        {
            this.StackCircles.Clear();
        }


        /** ************************************************************************
        * \brief Desenha um círculo.
        * \details Função responsável por desenhar um círculo neste campo.
        * \param circle Círculo que será desenhado.
        ***************************************************************************/
        public void DrawCircle(Circle circle)
        {
            SolidBrush solidBrush;

            // Limpa o campo antes de desenhar o círculo
            this.EraseField();

            if (circle == null)
            {
                this.StackCircles.Clear();
                return;
            }

            Graphics paper = this.FieldPictureBox.CreateGraphics();

            // Verifica qual tipo de cor o círculo terá
            if (circle.Color.TypeCurrent == ColorType.Primary)
            {
                solidBrush = new SolidBrush(circle.Color.Primary);
            }
            else
            {
                solidBrush = new SolidBrush(circle.Color.Secundary);
            }

            // Desenha o círculo informado
            paper.FillEllipse(solidBrush, circle.X, circle.Y, circle.Width, circle.Height);
        }


        /** ************************************************************************
        * \brief Limpa o campo.
        * \details Função responsável por limpar o campo.
        ***************************************************************************/
        public void EraseField()
        {
            Graphics paper = this.FieldPictureBox.CreateGraphics();
            SolidBrush solidBrush = new SolidBrush(Color.FromArgb(240, 240, 240)); // Cor inicial do campo
            Size size = this.FieldPictureBox.Size;
            paper.FillRectangle(solidBrush, 0, 0, size.Width, size.Height);
        }


        /** ************************************************************************
        * \brief Compara dois campos.
        * \details Função sobrescrita responsável por comprar dois objetos do tipo 
        * Field.
        * \param obj Campo que será comparado.
        * \return Um valor do tipo booleano, inicando se os dois campos comparados
        * são iguais ou não.
        ***************************************************************************/
        public override bool Equals(object obj)
        {
            Circle circle = this.GetLast();

            if ((!(obj is Field)) || (circle == null))
            {
                return false;
            }

            // Realizar um downcasting
            Field other = obj as Field;  
            return circle.Equals(other.GetLast());
        }


        /** ************************************************************************
        * \brief Gera a chave hash referente ao campo.
        * \details Função sobrescrita responsável por gerar uma chave hash referente 
        * a este campo.
        * \return Um valor do tipo inteiro, que consiste na chave hash referente 
        * ao campo.
        ***************************************************************************/
        public override int GetHashCode()
        {
            return this.GetLast().GetHashCode();
        }
    }
}
