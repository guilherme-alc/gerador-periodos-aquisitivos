namespace GeradorPeriodosAquisitivos.Style
{
    public class MenuPrincipalRenderer : ToolStripProfessionalRenderer
    {
        public MenuPrincipalRenderer() : base(new ProfessionalColorTable()) { }

        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            if (e.Item.Selected) // Quando o mouse passa sobre o item
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.Maroon), e.Item.ContentRectangle);
            }
            else if (e.Item.Pressed) // Quando o item está selecionado (clicado)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.Maroon), e.Item.ContentRectangle);
            }
            else
            {
                base.OnRenderMenuItemBackground(e); // Mantém a cor padrão definida no Designer
            }
        }

        protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
        {
            if (e.ToolStrip is ToolStripDropDownMenu) // Verifica se é um submenu
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.Firebrick), e.AffectedBounds); // Define a cor do fundo da bandeja
            }
            else
            {
                base.OnRenderToolStripBackground(e);
            }
        }
    }
}
