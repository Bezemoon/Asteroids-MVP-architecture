using CodeBase.Infrastructures.Services;
using UnityEngine;

namespace CodeBase.Infrastructures.AssetManagement
{
    public interface IAsset : IService
    {
        GameObject Instantiate(string path);
        GameObject Instantiate(string path, Vector3 at);
    }
}