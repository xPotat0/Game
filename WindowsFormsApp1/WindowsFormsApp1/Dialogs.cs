using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dialog
{
    public class DialogsPope
    {
        public static string[] Dialog = new string[13]
        {
            "Приветствую тебя, брат!",
            "Сегодня у меня для тебя есть поручение...",
            "Мост через реку обвалился и мне нужно,\nчтобы ты передал мою просьбу починить мост\nЛесничему Дувину...",
            "Сообщи мне, когда мост будет починен!",
            "Мост уже починен?",
            "Хм, повредил ногу говоришь...\nЯ знаю, как ему помочь!",
            "Я изготовлю Дувину лечебный элексир.\nТолько меня память подводит.\nПринеси мне мою книгу, чтобы я вспомнил рецепт!",
            "Ты принёс книгу?",
            "Гм... Отлично! Все ингридиенты, которые\nмне понадобятся для готовки можно найти\nв наших краях.",
            "Принеси мне Сердцецвет и водяную лилию!\nСердцецвет ты сможешь найти в лесу,а\nводяную лилию можно найти около воды.",
            "Ты принёс всё, что нужно?",
            "Держи. Отнеси это Дувину.\nКогда мост будет починен, сообщи мне.",
            "\n\n\n                     Game over"
        };
        public static int dialogStatus { get; set; }
    }

    public class DialogsHunt
    {
        public static string[] Dialog = new string[11]
        {
            "Привет, рыцарь. Зачем пожаловал?",
            "Мост? Я сделал его на совесть!\nОн не должен был обвалиться!",
            "Ладно, неважно... Я бы и хотел\nпомочь тебе, да только я повредил ногу\nна последней рубке леса..." ,
            "Никак не могу подняться до\nчердака, чтобы взять лечебный элексир.\nПодсобишь?\nВозьми этот ключ.\nОн поможет тебе открыть закрытые двери",
            "Притащил?",
            "Кончился? Вот незадача...\nСпроси, где можно достать элексир у Вангорича. \nОн навярника знает.",
            "...",
            "Ну что? Смог достать элексир?\nДавай сюда",
            "Да, так гораздо лучше.\nЯ ещё немного посижу и потом пойду.\nСтупай к мосту! Вот увидишь, я окажусь там раньше тебя!",
            "Ха! Я же говорил, что буду здесь раньше тебя!\nПока ты шёл, я уже успел починить мост.\nКак? Магия!",
            "Ступай и расскажи Вангоричу, что мост починен"
        };
        public static int dialogStatus { get; set; }
    }

    public class Pointer
    {
        public static string str = "                            Лес - наверх\n\n\n\nЛуг-налево                                           Церковь-направо\n\n\n\n                            Лесничий-вниз";
    }
}
