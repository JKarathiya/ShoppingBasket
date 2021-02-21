Feature: Shopping Basket Discount Task
	In order to purchase product
	As a potential customer
	I want to add products in a shopping basket with discount code
	So that I can order several products at once

Scenario: Basket 1
	Given Add 1 Jumper @ £54.65 to basket
	And   Add 1 Head Light (Head Gear Category of Product) @ £3.50 to basket
	When  I calls GetBasketTotalAmount()
	Then  I should see overalls price is £58.15

Scenario: Basket 2
	Given Add 1 Gloves @ £10.50 to basket
	And   Add 1 Jumper @ £54.65 to basket
	And   Apply 1 x £5.00 Gift Voucher XXX-XXX
	When  I calls GetBasketTotalAmount()
	Then  I should see overalls price is £60.15

Scenario: Basket 3
	Given Add 1 Gloves @ £25.00 to basket
	And   Add 1 Jumper @ £26.00 to basket
	And   1 x £5.00 off Head Gear in baskets over £50.00 Offer Voucher YYY-YYY applied
	When  I calls GetBasketTotalAmount()
	Then  I should see overalls price is £51.00
	Then  Message: “There are no products in your basket applicable to Offer Voucher YYY-YYY.”

Scenario: Basket 4
	Given Add 1 Gloves @ £25.00 to basket
	And   Add 1 Jumper @ £26.00 to basket
	And   Add 1 Head Light (Head Gear Category of Product) @ £3.50 to basket
	And   1 x £5.00 off Head Gear in baskets over £50.00 Offer Voucher YYY-YYY applied
	When  I calls GetBasketTotalAmount()
	Then  I should see overalls price is £51.00

Scenario: Basket 5:
	Given Add 1 Gloves @ £25.00 to basket
	And   Add 1 Jumper @ £26.00 to basket
	And   Apply 1 x £5.00 Gift Voucher XXX-XXX
	And   Apply 1 x £5.00 off baskets over £50.00 Offer Voucher YYY-YYY applied
	When  I calls GetBasketTotalAmount()
	Then  I should see overalls price is £41.00

Scenario: Basket 6:
	Given Add 1 Gloves @ £25.00 to basket
	And   Add 1 £30 Gift Voucher @ £30.00 to basket
	And   Apply 1 x £5.00 off baskets over £50.00 Offer Voucher YYY-YYY applied
	When  I calls GetBasketTotalAmount()
	Then  I should see overalls price is £55.00
	Then  Message: “You have not reached the spend threshold for Gift Voucher YYY-YYY. Spend another £25.01 to receive £5.00 discount from your basket total.”

Scenario: Basket 7:
	Given Add 1 Gloves @ £25.00 to basket 
	And   Apply 1 x £30.00 Gift Voucher XXX-XXX
	When  I calls GetBasketTotalAmount()
	Then  I should see overalls price is £0.00