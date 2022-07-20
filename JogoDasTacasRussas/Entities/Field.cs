/*******************************************************************************
 * Arquivo: Field.cs                                                           *
 * Autor: Thiago Sérvulo Guimarães                                             *
 * Data: 20/07/2022                                                            *
 *                                                                             *
 * Classe: Field                                                               *
 * Descrição: A classe 'Field' armazena as informações referentes aos campos   *
 *   que o tabuleiro irá conter.                                               *
 * Atributos:                                                                  *
 *   FieldPictureBox [PictureBox]: 'pictureBox' referente a este campo.        *
 *   StackCircles [Stack<Circle>]: Pilha que recebe os círculos adicionados    *
 *                                 a este campo.                               *
 *******************************************************************************/

using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using JogoDasTacasRussas.Entities.Enums;

namespace JogoDasTacasRussas.Entities
{
    class Field
    {
        //----------------------------------------------------------------------
        // Atributos
        //----------------------------------------------------------------------
        public PictureBox FieldPictureBox { get; private set; }
        public Stack<Circle> StackCircles { get; private set; }

        //----------------------------------------------------------------------
        // Construtor da classe 'Field'
        //----------------------------------------------------------------------
        public Field(PictureBox pictureBox)
        {
            this.FieldPictureBox = pictureBox;
            this.StackCircles = new Stack<Circle>();
            this.StackCircles.Clear();
        }

        //----------------------------------------------------------------------
        // Descrição:
        //    Função responsável por adicionar um círculo ao topo da pilha.
        // Parâmetros:
        //    Nenhum.
        // Retorno:
        //    Nenhum.
        //----------------------------------------------------------------------
        public void AddCircle(Circle circle)
        {
            // Adiciona o círculo ao topo da pilha
            this.StackCircles.Push(circle);

            // Desenha o novo círculo que se encontra no topo da pilha
            this.DrawCircle(circle);
        }

        //----------------------------------------------------------------------
        // Descrição:
        //    Função responsável por remover o círculo que está no topo da pilha
        //    deste campo e retorna-o.
        // Parâmetros:
        //    Nenhum.
        // Retorno:
        //    Valor do tipo 'Circle', que corresponde ao círculo que estava no
        //    topo da pilha.
        //----------------------------------------------------------------------
        public Circle PopCircle()
        {
            // Remove o círculo que está no topo da pilha
            Circle circle = this.StackCircles.Pop();

            // Desenha o novo círculo que se encontra no topo da pilha
            this.DrawCircle(this.GetLast());
            return circle;
        }

        //----------------------------------------------------------------------
        // Descrição:
        //    Função responsável por trocar a cor de um determinado círculo.
        // Parâmetros:
        //    Nenhum.
        // Retorno:
        //    Nenhum.
        //----------------------------------------------------------------------
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

        //----------------------------------------------------------------------
        // Descrição:
        //    Função responsável por pegar o círculo que se encontra no topo da
        //    pilha e retornar suas informações.
        // Parâmetros:
        //    Nenhum.
        // Retorno:
        //    Valor do tipo 'Circle', que corresponde ao círculo que está no
        //    topo da pilha.
        //----------------------------------------------------------------------
        public Circle GetLast()
        {
            if (this.StackCircles.Count == 0)
            {
                return null;
            }
            return this.StackCircles.Peek();
        }

        //----------------------------------------------------------------------
        // Descrição:
        //    Função responsável por limpar a pilha de círculos.
        // Parâmetros:
        //    Nenhum.
        // Retorno:
        //    Nenhum.
        //----------------------------------------------------------------------
        public void Clear()
        {
            this.StackCircles.Clear();
        }

        //----------------------------------------------------------------------
        // Descrição:
        //    Função responsável por desenhar um círculo em um campo.
        // Parâmetros:
        //    circle [Circle]: Círculo que será desenhado.
        // Retorno:
        //    Nenhum.
        //----------------------------------------------------------------------
        private void DrawCircle(Circle circle)
        {
            SolidBrush solidBrush;

            // Limpa o campo antes de desenhar o círculo
            this.EraseField();

            if (circle == null)
            {
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

        //----------------------------------------------------------------------
        // Descrição:
        //    Função responsável por limpar o campo.
        // Parâmetros:
        //    Nenhum.
        // Retorno:
        //    Nenhum.
        //----------------------------------------------------------------------
        public void EraseField()
        {
            Graphics paper = FieldPictureBox.CreateGraphics();
            SolidBrush solidBrush = new SolidBrush(Color.FromArgb(240, 240, 240)); // Cor inicial do campo
            Size size = FieldPictureBox.Size;
            paper.FillRectangle(solidBrush, 0, 0, size.Width, size.Height);
        }

        //----------------------------------------------------------------------
        // Descrição:
        //    Função sobrescrita responsável por comprar dois objetos do tipo
        //    'Field'.
        // Parâmetros:
        //    obj [object]: Objeto do tipo 'Field' que será comparado.
        // Retorno:
        //    Um valor do tipo 'bool', inicando se os dois objetos comparados
        //    são iguais ou não.
        //----------------------------------------------------------------------
        public override bool Equals(object obj)
        {
            Circle circle = this.GetLast();

            if ((!(obj is Field)) || (circle == null))
            {
                return false;
            }

            Field other = obj as Field;  // Downcasting
            return circle.Equals(other.GetLast());
        }

        //----------------------------------------------------------------------
        // Descrição:
        //    Função sobrescrita responsável por gerar uma hash referente a este
        //    objeto.
        // Parâmetros:
        //    Nenhum.
        // Retorno:
        //    Um valor do tipo 'int', que consiste na chave referente ao objeto.
        //----------------------------------------------------------------------
        public override int GetHashCode()
        {
            return this.GetLast().GetHashCode();
        }
    }
}
