import { Component, OnInit, QueryList, ViewChildren } from '@angular/core';
import { Location } from 'src/app/models/location';
import { LocationService } from 'src/app/services/location.service';
import { MapInfoWindow, MapMarker } from '@angular/google-maps';

@Component({
  selector: 'app-map',
  templateUrl: './map.component.html',
  styleUrls: ['./map.component.scss']
})
export class MapComponent implements OnInit {
  @ViewChildren(MapInfoWindow) infoWindowsView: QueryList<MapInfoWindow> | undefined;

  locations: Location[] = [];

  loading: boolean = false;

  zoom = 12;
  center: google.maps.LatLngLiteral = { lat: 45.078132, lng: 13.641608 };
  markerOptions = { draggable: false };
  markerPositions: google.maps.LatLng[] = [];

  constructor(
    private locationAPi: LocationService) { }

  ngOnInit(): void {
    this.getLocations();
  }

  getLocations() {
    this.loading = true;
    this.locationAPi.getLocations()
      .then(res => {
        this.locations = res;
        this.markerPositions = this.locations.map((location) =>
          new google.maps.LatLng(location.latitude, location.longitude));
        this.loading = false;
      })
  }

  setPosition(lat: number, lng: number) {
    return new google.maps.LatLng(lat, lng);
  }

  openInfoWindow(marker: MapMarker, windowIndex: number) {
    /// stores the current index in forEach
    if (this.infoWindowsView !== undefined) {
      let curIdx = 0;
      this.infoWindowsView.forEach((window: MapInfoWindow) => {
        if (windowIndex === curIdx) {
          window.open(marker);
          curIdx++;
        } else {
          curIdx++;
        }
      });
    }
  }
}
