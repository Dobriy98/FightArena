using System;
using Inputs;
using Zenject;

namespace Characters.MainCharacterModel
{
    public class MainCharacter : Character
    {
        private IMouseService _mouseService;

        [Inject]
        public void Construct(IMouseService mouseService)
        {
            _mouseService = mouseService ?? throw new ArgumentNullException();
        }

        protected override void Start()
        {
            base.Start();
            _mouseService.OnEnvironmentRightClick += _characterMovement.MoveTo;
            _mouseService.OnEnvironmentLeftClick += _attackBehavior.Attack;
        }

        private void OnDisable()
        {
            _mouseService.OnEnvironmentRightClick -= _characterMovement.MoveTo;
            _mouseService.OnEnvironmentLeftClick -= _attackBehavior.Attack;
        }
    }
}