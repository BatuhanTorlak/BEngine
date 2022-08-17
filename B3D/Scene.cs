#define BGAMEENGINE

using BEngine.List;

namespace BEngine.B3D
{
    public class Scene
    {
        internal BString Path;
        internal BList<Object> SceneObjs;
        internal bool IsActiveScene;

        internal Scene(BString FilePath)
        {
            Path = FilePath;
            SceneObjs = new BList<Object>();
            IsActiveScene = false;

            // import scene...

            Load();
        }

        internal void Load()
        {
            foreach(var x in SceneObjs.ToArray())
            {
                foreach (var z in x.components.ToArray())
                {
                    z.Start();
                }
            }
        }

        internal void Update()
        {
            foreach(var x in SceneObjs.ToArray())
            {
                foreach(var z in x.components.ToArray())
                {
                    z.Update();
                }
            }
            if (!IsActiveScene)
                return;
            Update();
        }

        public Scene StartVersion()
        {
            var i = new Scene(Path);
            return i;
        }

        public static Scene GenerateNullScene()
        {
            return new Scene(@"C:\");
        }
    }
}