import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CommongridComponent } from './commongrid.component';

describe('CommongridComponent', () => {
  let component: CommongridComponent;
  let fixture: ComponentFixture<CommongridComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CommongridComponent]
    });
    fixture = TestBed.createComponent(CommongridComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
