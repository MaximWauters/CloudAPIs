import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GalleryDbComponent } from './gallery-db.component';

describe('GalleryDbComponent', () => {
  let component: GalleryDbComponent;
  let fixture: ComponentFixture<GalleryDbComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GalleryDbComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GalleryDbComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
