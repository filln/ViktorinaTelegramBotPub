//Принимает и проверяет данные от телеграма.


using Microsoft.AspNetCore.Mvc;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace ViktorinaTelegramBot
{
    public class WebhookController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Post([FromServices] HandleUpdateService handleUpdateService,
                                              [FromBody] Update update)
        {
            if(update == null)
            {
                Console.WriteLine("update == null");
                return Ok();
            }
            if (update.Message == null)
            {
                Console.WriteLine("update.Message == null");
                return Ok();
            }
            if(update.Message.Text == null)
            {
                Console.WriteLine("update.Message.Text == null");
                return Ok();
            }
            if (update.Message.Chat == null)
            {
                Console.WriteLine("update.Message.Chat == null");
                return Ok();
            }
            if (update.Message.From == null)
            {
                Console.WriteLine("update.Message.From == null");
                return Ok();
            }
            if (update.Message.From.IsBot)
            {
                Console.WriteLine("update.Message.From.IsBot == true ");
                return Ok();
            }

            //Private chats forbid.
            if (update!.Message!.Chat.Id > 0)
            {
                return Ok();
            }

            if (update!.Message!.Type != MessageType.Text)
            {
                return Ok();
            }

            if (update!.Message!.Text[0] == ' ')
            {
                return Ok();
            }
            bool emptySymbolsPresentEverywhere = true;
            foreach (char symbol in update!.Message!.Text)
            {
                if
                    (
                        symbol != '\n'
                        && symbol != '\t'
                    )
                {
                    emptySymbolsPresentEverywhere = false;
                }
                else
                {
                    emptySymbolsPresentEverywhere = true;
                    break;
                }
            }
            if (emptySymbolsPresentEverywhere)
            {
                return Ok();
            }

            await handleUpdateService.EchoAsync(update);
            return Ok();
        }


    }
}
