using UnityEngine;

namespace Systems.EntitySystem
{
    public class Target
    {
        private GameObject _gameObj;
        private Entity _entity;

        public GameObject gameObj
        {
            get
            {
                return _gameObj;
            }
        }

        public Entity entity
        {
            get
            {
                if (_entity == null)
                {
                    if (gameObj != null)
                    {
                        _entity = gameObj.GetComponent<Entity>();
                    }
                }
                return _entity;
            }
        }

        public Target()
        {
            _gameObj = null;
            _entity = null;
        }

        public void SetTarget(GameObject go)
        {
            _gameObj = go;
            _entity = go.GetComponent<Entity>();
        }
    }
}