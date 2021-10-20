/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { AdminRouteGuardService } from './admin-route-guard.service';

describe('Service: AdminRouteGuard', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [AdminRouteGuardService]
    });
  });

  it('should ...', inject([AdminRouteGuardService], (service: AdminRouteGuardService) => {
    expect(service).toBeTruthy();
  }));
});
