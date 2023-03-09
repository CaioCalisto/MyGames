using NUnit.Framework;
using UnityEngine;

public class CarTests
{
    /*
     * A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
     * `yield return null;` to skip a frame.
        All Unity unit tests are coroutines, so you need to add a yield return.
        You’re also adding a time-step of 0.1 seconds to simulate the movement
         
        yield return new WaitForSeconds(0.1f);
     */
    
    [Test]
    public void CarShouldBeGrounded()
    {
        // Arrange
        GameObject game = new GameObject();
        Car car = game.AddComponent<Car>();
        var actualPosition = car.transform.position;
        
        // Act
        car.MoveForward(0.002f);

        // Assert
        Assert.Greater(car.transform.position.z, actualPosition.z);
    }
}
