// ファイル名: FasterFall.cs （推奨版）
// 落下中に追加重力を与えて、落下と安定を速める補助コンポーネント。
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class FasterFall : MonoBehaviour
{
    // 元の重力に対する落下速度の倍率 (例: 2.5なら2.5倍の速さで落ちる)
    public float fallMultiplier = 2.5f;

    private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // 落下中（Y軸の速度がマイナス）の場合
        if (rb.linearVelocity.y < 0)
        {
            // (倍率 - 1) 分の追加の重力を、力を加える形で適用します。
            // これが最もシンプルで安定した方法です。
            rb.AddForce(Physics.gravity * (fallMultiplier - 1), ForceMode.Acceleration);
        }
    }
}
