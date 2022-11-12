using Stride.Core.Mathematics;
using Stride.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doprez.Stride.DoprezMath;
public static class MathHelper
{

	/// <summary>
	/// Return degrees from radians as a float
	/// </summary>
	/// <param name="radians"></param>
	/// <returns></returns>
	public static float RadiansToDegrees(float radians)
	{
		double degrees = (180 / Math.PI) * radians;

		return (float)degrees;
	}

	/// <summary>
	/// Return degrees from radians as a double
	/// </summary>
	/// <param name="radians"></param>
	/// <returns></returns>
	public static double RadiansToDegrees(double radians)
	{
		double degrees = (180 / Math.PI) * radians;

		return degrees;
	}

	/// <summary>
	/// Returns the Y angle in radians between two Vector3's only using the X and Z values
	/// </summary>
	/// <param name="entity"></param>
	/// <param name="targetPosition"></param>
	/// <returns></returns>
	public static float GetYAngleToTarget(Vector3 currentPosition, Vector3 targetPosition)
	{
		double angleInRadians = Math.Atan2(targetPosition.Z - currentPosition.Z, targetPosition.X - currentPosition.X);

		return (float)angleInRadians;
	}

}
