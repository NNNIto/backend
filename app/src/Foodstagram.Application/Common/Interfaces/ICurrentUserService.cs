// src/Foodstagram.Application/Common/Interfaces/ICurrentUserService.cs
namespace Foodstagram.Application.Common.Interfaces;

/// <summary>
/// 「現在ログインしているユーザー」に関する情報を提供するサービス。
/// API 層では HttpContext / JWT から ID を取り出し、
/// Application 層はこのインターフェースだけを見る。
/// </summary>
public interface ICurrentUserService
{
    /// <summary>
    /// ログインユーザーの UserId。
    /// 未ログインを許可したい場合は null 許容などにしてもよい。
    /// </summary>
    long UserId { get; }
}
