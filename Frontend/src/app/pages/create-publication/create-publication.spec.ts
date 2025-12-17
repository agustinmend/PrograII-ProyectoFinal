import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreatePublication } from './create-publication';

describe('CreatePublication', () => {
  let component: CreatePublication;
  let fixture: ComponentFixture<CreatePublication>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CreatePublication]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CreatePublication);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
