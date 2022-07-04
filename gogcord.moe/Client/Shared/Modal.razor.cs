using Microsoft.JSInterop;

namespace gogcord.moe.Client.Shared
{
  public partial class Modal
  {
    public static Modal theModal { get; private set; }

    public string? ModalHidden => !ShouldShow ? "modal-hidden" : null;
    public bool ShouldShow = false;

    public Modal()
    {
      theModal = this;
    }

    public async Task HideModal()
    {
      ShouldShow = false;
      StateHasChanged();
    }
    public async Task ShowModal()
    {
      ShouldShow = true;
      StateHasChanged();
    }

    [JSInvokable]
    public static Task StaticHideModal()
    {
      theModal.HideModal();
      return Task.CompletedTask;
    }

    [JSInvokable]
    public static Task StaticShowModal()
    {
      theModal.ShowModal();
      return Task.CompletedTask;
    }
  }
}
