// Copyright 2022 Anatoli Kucharau https://vk.com/ulvprog. All Rights Reserved.

/**
 * Управляет количеством ответов подряд для статистики или для суперигры.
 */

namespace Viktorina.Bot
{
    public class RightAnswersCountInARow
    {
        public RightAnswersCountInARow()
        {
            username = "";
            count = 0;
        }

        private string username; //имя игрока
        private int count;    //количество ответов подряд для суперигры.


        public int GetCurrentAnswersInARow()
        {
            return count;
        }
        public void IncrCurrentAnswersInARow(string username)
        {
            if (username != this.username)
            {
                ResetCurrentAnswersInARow();
            }
            count++;
        }
        public void ResetCurrentAnswersInARow()
        {
            username = "";
            count = 0;
        }


    }
}
