import { TestBed } from '@angular/core/testing';

import { GetboekenService } from './getboeken.service';

describe('GetboekenService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: GetboekenService = TestBed.get(GetboekenService);
    expect(service).toBeTruthy();
  });
});
