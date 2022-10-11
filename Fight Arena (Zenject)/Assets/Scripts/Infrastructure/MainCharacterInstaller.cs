using System;
using Characters;
using Characters.MainCharacterModel;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace Infrastructure
{
    public class MainCharacterInstaller : MonoInstaller
    {
        [SerializeField] private Transform mainCharacterStartMarker;
        [SerializeField] private MainCharacter mainCharacterPrefab;
        public override void InstallBindings()
        {
            BindMainCharacter();
        }
        void BindMainCharacter() 
        {
            MainCharacter mainCharacterInstance = Container
                .InstantiatePrefabForComponent<MainCharacter>(mainCharacterPrefab, mainCharacterStartMarker.position,
                    Quaternion.identity, null);

            Container
                .Bind<MainCharacter>()
                .FromInstance(mainCharacterInstance)
                .AsSingle();
            
        }
    }
}
