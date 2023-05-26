namespace Mapbox.Examples
{
	using Mapbox.Unity.Location;
	using Mapbox.Unity.Map;
	using Mapbox.Unity.Utilities;
	using Mapbox.Utils;
	using UnityEngine;

	public class ImmediatePositionWithLocationProvider : MonoBehaviour
	{

		bool _isInitialized;
		private bool moveRight = false;
		private bool moveLeft = false;
		private bool moveUp = false;
		private bool moveDown = false;
		Vector2d i = new Vector2d(0,0);
		int j = 0;

		ILocationProvider _locationProvider;
		ILocationProvider LocationProvider
		{
			get
			{
				if (_locationProvider == null)
				{
					_locationProvider = LocationProviderFactory.Instance.DefaultLocationProvider;
				}

				return _locationProvider;
			}
		}

		Vector3 _targetPosition;

		void Start()
		{
			LocationProviderFactory.Instance.mapManager.OnInitialized += () => _isInitialized = true;
			var map = LocationProviderFactory.Instance.mapManager;
			transform.localPosition = map.GeoToWorldPosition(LocationProvider.CurrentLocation.LatitudeLongitude);
		}

		void LateUpdate()
		{


			if (_isInitialized)
			{
				// var map = LocationProviderFactory.Instance.mapManager;
				// transform.localPosition = map.GeoToWorldPosition(LocationProvider.CurrentLocation.LatitudeLongitude);
			}
			Vector3 playerPos = transform.localPosition;
			// move into seperate file
			// handles movement of character while debugging
			if (Input.GetKeyDown(KeyCode.W)) {
				moveUp = true;
			}
			if (Input.GetKeyDown(KeyCode.S)) {
				moveDown = true;
			}
			if (Input.GetKeyDown(KeyCode.D)) {
				moveRight = true;
			}
			if (Input.GetKeyDown(KeyCode.A)) {
				moveLeft = true;
			}

			if (Input.GetKeyUp(KeyCode.W)) {
				moveUp = false;
			}
			if (Input.GetKeyUp(KeyCode.S)) {
				moveDown = false;
			}
			if (Input.GetKeyUp(KeyCode.D)) {
				moveRight = false;
			}
			if (Input.GetKeyUp(KeyCode.A)) {
				moveLeft = false;
			}

			if (moveRight) {
				playerPos.x += 1;
			}
			if (moveLeft) {
				playerPos.x -= 1;
			}
			if (moveUp) {
				playerPos.z += 1;
			}
			if (moveDown) {
				playerPos.z -= 1;
			}
			transform.localPosition = playerPos;

			// var map = LocationProviderFactory.Instance.mapManager;
			// transform.localPosition = map.GeoToWorldPosition(LocationProvider.CurrentLocation.LatitudeLongitude);

		}
	}
}