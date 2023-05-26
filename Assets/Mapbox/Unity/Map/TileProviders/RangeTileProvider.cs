using System.Collections.Generic;
using Mapbox.Map;
using UnityEngine;

namespace Mapbox.Unity.Map.TileProviders
{
	public class RangeTileProvider : AbstractTileProvider
	{
		private RangeTileProviderOptions _rangeTileProviderOptions;
		private bool _initialized = false;

		public override void OnInitialized()
		{
			if (Options != null)
			{
				_rangeTileProviderOptions = (RangeTileProviderOptions)Options;
			}
			else
			{
				_rangeTileProviderOptions = new RangeTileProviderOptions();
			}
			
			_initialized = true;
			_currentExtent.activeTiles = new HashSet<UnwrappedTileId>();
		}

		public override void UpdateTileExtent()
		{
			if (!_initialized || _rangeTileProviderOptions == null)
			{
				return;
			}
			// added this 
			// get camera, find direction it is facing object
			// GameObject camera = GameObject.Find("Main Camera");
			// Debug.Log(camera.transform.forward);
			_rangeTileProviderOptions.SetOptions(10,10,10,10);

			
			// _rangeTileProviderOptions.SetOptions(5,5,5,5);



			_currentExtent.activeTiles.Clear();
			// set to be centred at player TODO
			var centerTile = TileCover.CoordinateToTileId(_map.CenterLatitudeLongitude, _map.AbsoluteZoom);
			_currentExtent.activeTiles.Add(new UnwrappedTileId(_map.AbsoluteZoom, centerTile.X, centerTile.Y));

			for (int x = (centerTile.X - _rangeTileProviderOptions.west); x <= (centerTile.X + _rangeTileProviderOptions.east); x++)
			{
				for (int y = (centerTile.Y - _rangeTileProviderOptions.north); y <= (centerTile.Y + _rangeTileProviderOptions.south); y++)
				{
					_currentExtent.activeTiles.Add(new UnwrappedTileId(_map.AbsoluteZoom, x, y));
				}
			}

			OnExtentChanged();
		}
		public override bool Cleanup(UnwrappedTileId tile)
		{
			return (!_currentExtent.activeTiles.Contains(tile));
		}

	}
}
