namespace BEngine.B3D
{
    public static class SceneManager
    {
        private static Scene _ActiveScene;
        public static Scene ActiveScene
        {
            internal set
            {
                if (_ActiveScene != null)
                    _ActiveScene.IsActiveScene = false;
                value.IsActiveScene = true;
                _ActiveScene = value;
            }
            get => _ActiveScene;
        }

        public static void SetActiveScene(Scene scene)
        {
            ActiveScene = scene;
        }

        public static void RunStartMethod()
        {
            _ActiveScene.Load();
        }
    }
}