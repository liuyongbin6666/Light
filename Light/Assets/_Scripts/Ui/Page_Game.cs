using GMVC.Core;
using GMVC.Views;
using UnityEngine.UI;

public class Page_Game : UiBase
{
    View_PlayerInfo view_playerInfo { get; }

    public Page_Game(IView v) :
        base(v)
    {
        view_playerInfo = new View_PlayerInfo(v.Get<View>("view_playerInfo"));

        Game.RegEvent(GameEvent.Game_StateChanged, b =>
        {
            var state = Game.World.Status;
            Display(state == GameWorld.GameStates.Playing);
            view_playerInfo.UpdateLantern(Game.World.Stage.Player.Lantern);
        });
        Game.RegEvent(GameEvent.Player_Lantern_Update,
                      _ => view_playerInfo.UpdateLantern(Game.World.Stage.Player.Lantern));
    }

    class View_PlayerInfo : UiBase
    {
        Element_TextValue element_textValue_lantern { get; }
        public View_PlayerInfo(IView v) : base(v)
        {
            element_textValue_lantern = new Element_TextValue(v.Get<View>("element_textValue_lantern"), "虫灯");
            element_textValue_lantern.SetValue(0);
        }
        public void UpdateLantern(int value) => element_textValue_lantern.SetValue(value);
        class Element_TextValue : UiBase
        {
            Text text_title { get; }
            Text text_value { get; }
            public Element_TextValue(IView v,string title) : base(v)
            {
                text_title = v.Get<Text>("text_title");
                text_value = v.Get<Text>("text_value");
                text_title.text = title;
            }
            public void SetValue(object value) => text_value.text = value.ToString();
        }
    }
}