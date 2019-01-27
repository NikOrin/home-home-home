using System.Collections.Generic;
using System;

namespace Application.Story
{
    public class StoryMaster
    {
        public List<string> Keys;

        public StoryController Controller;

        public StoryMaster()
        {
        }

        public void StoryKeyPointReached(string key){
            Controller.StoryKeyPointReached(key);
        }
    }
}
