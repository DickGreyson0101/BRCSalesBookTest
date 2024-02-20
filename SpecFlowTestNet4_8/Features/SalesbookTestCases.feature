Feature: SalesbookTestCases
Testcases will be written here 


Rule: Add Sales Entries
  Scenario Outline: Verify if new Sales Entries record has been added with valid data  
    Given The user is in "salesInvoicing" window
    When The user performs the following actions:
      | Action        | Element            | Type               | Detail | Window          |
      | Clicks        | Add                | Button             |        | salesInvoicing  |
      | Selects       | Sales Book Entries | Radio              |        | selectEntryType |
      | Clicks        | OK                 | Button             |        | selectEntryType |
      | Enters        | Account:           | Input              | CUS1   | salesBookEntry  |
      | Enters        | Total:             | Input              | 100    | salesBookEntry  |
      | Double clicks | 1                  | VATAnalysis        |        | salesBookEntry  |
      | Enters        | 1                  | AnalysisCategories | 10     | salesBookEntry  |
      | Enters        | 2                  | AnalysisCategories | 10     | salesBookEntry  |
      | Enters        | 3                  | AnalysisCategories | 10     | salesBookEntry  |
      | Double clicks | 4                  | AnalysisCategories |        | salesBookEntry  |
      | Clicks        | Save               | Button             |        | salesBookEntry  |
      | Clicks        | Cancel             | Button             |        | salesBookEntry  |

    Then Verify the following actions:
    | Action            | Element | Type     | Detail | Window             |
    | Checks new record | .       | DataGrid |        | salesInvoicingBook |

  Scenario Outline: Verify if new Sales Entries record has been added with empty data
    Given The user is in "salesInvoicing" window
    When The user performs the following actions:
      | Action  | Element            | Type   | Detail | Window          |
      | Clicks  | Add                | Button |        | salesInvoicing  |
      | Selects | Sales Book Entries | Radio  |        | selectEntryType |
      | Clicks  | OK                 | Button |        | selectEntryType |
      | Clicks  | Save               | Button |        | salesBookEntry  |
    Then Verify the following actions:
      | Action           | Element                                 | Type    | Detail | Window |
      | Checks existence | Customer Account Code must be specified | ToolTip |        |        |


Scenario Outline: Verify if new Sales Entries record has been added with invalid data  
    Given The user is in "salesInvoicing" window
    When The user performs the following actions:
      | Action        | Element            | Type               | Detail | Window          |
      | Clicks        | Add                | Button             |        | salesInvoicing  |
      | Selects       | Sales Book Entries | Radio              |        | selectEntryType |
      | Clicks        | OK                 | Button             |        | selectEntryType |
      | Enters        | Account:           | Input              | CUS1   | salesBookEntry  |
      | Enters        | Total:             | Input              | 100    | salesBookEntry  |
      | Double clicks | 1                  | VATAnalysis        |        | salesBookEntry  |
      | Enters        | 1                  | AnalysisCategories | 10     | salesBookEntry  |
      | Enters        | 2                  | AnalysisCategories | 10     | salesBookEntry  |
      | Enters        | 3                  | AnalysisCategories | 10     | salesBookEntry  |
      | Clicks        | Save               | Button             |        | salesBookEntry  |
    Then Verify the following actions:
      | Action           | Element                                               | Type    | Detail | Window |
      | Checks existence | The total net amount has not been analysed correctly! | ToolTip |        |        |



Rule: Add Sales Invoice
  Scenario Outline: Verify if new Sales Invoice record has been added with valid data 
    Given The user is in "salesInvoicing" window
    When The user performs the following actions:
      | Action        | Element         | Type                    | Detail  | Window                 |
      | Clicks        | Add             | Button                  |         | salesInvoicing         |
      | Selects       | Sales Invoices               | Radio                   |         | selectEntryType        |
      | Clicks        | OK              | Button                  |         | selectEntryType        |

      | Enters        | Your Reference: | Input                   | yourRef | salesInvoicingBookEdit |
      | Enters        | Our Reference:  | Input                   | ourRef  | salesInvoicingBookEdit |
      | Enters        | Sales Rep:      | Input                   | CODE1   | salesInvoicingBookEdit |
      | Enters        | Account:        | Input                   | CUS1    | salesInvoicingBookEdit |
      | Clicks        | Add             | Button                  |         | salesInvoicingBookEdit |

      | Enters        | Product:        | Input                   | PROD1   | lineItemEdit           |
      | Enters        | Quantity:       | Input                   | 10      | lineItemEdit           |
      | Enters        | Unit Price:     | Input                   | 200     | lineItemEdit           |
      | Enters        | 1               | AnalysisCategories | 10      | lineItemEdit           |
      | Enters        | 2               | AnalysisCategories | 10      | lineItemEdit           |
      | Enters        | 3               | AnalysisCategories | 10      | lineItemEdit           |
      | Double clicks | 4               | AnalysisCategories |         | lineItemEdit           |
      | Clicks        | Save            | Button                  |         | lineItemEdit           |
      | Clicks        | Cancel          | Button                  |         | lineItemEdit           |

      | Clicks        | Yes             | Button                  |         | messagebox             |

      | Clicks        | Save            | Button                  |         | salesInvoicingBookEdit |
      | Clicks        | Cancel          | Button                  |         | salesInvoicingBookEdit |


Then Verify the following actions:
    | Action            | Element | Type     | Detail | Window             |
    | Checks new record | .       | DataGrid |        | salesInvoicingBook |


Rule: Change Sales Book Entries
  Scenario Outline: Verify if a Sales Book Entries record has been change with valid data 
    Given The user is in "salesInvoicing" window
    When The user performs the following actions:
      | Action        | Element  | Type               | Detail | Window             |
      | Clicks        | 1        | DataGrid           |        | salesInvoicingBook |
      | Clicks        | Change   | Button             |        | salesInvoicing     |
      | Enters        | Account: | Input              | CUS1   | salesBookEntry     |
      | Enters        | Name:    | Input              | Linh   | salesBookEntry     |
      | Enters        | Total:   | Input              | 300    | salesBookEntry     |
      | Double clicks | 2        | VATAnalysisInput   |        | salesBookEntry     |
      | Enters        | 1        | AnalysisCategories | 10     | salesBookEntry     |
      | Enters        | 2        | AnalysisCategories | 10     | salesBookEntry     |
      | Enters        | 3        | AnalysisCategories | 20     | salesBookEntry     |
      | Double clicks | 4        | AnalysisCategories |        | salesBookEntry     |
      | Clicks        | Save     | Button             |        | salesBookEntry     |
Then Verify the following actions:
    | Action         | Element | Type   | Detail | Window         |
    | Checks Display | Save    | Button |        | salesBookEntry |



Rule: Check visible 
Scenario Outline:  Verify if the report appeared with appropriate content 
Given The user is in "salesInvoicing" window
When The user performs the following actions:
| Action | Element                                                    | Type         | Detail         | Window |
| Clicks | Reports                                                    | ReportButton | upper button   |        |
| Clicks | Cash Book                                                  | ReportButton | in report list |        |
| Clicks | Cash Receipts Listing                                      | Button       |                |        |
| Clicks | Display                                                    | Button       |                |        |
| Waits  | https://brc-uat.azurewebsites.net/report/ReportViewer.aspx | Url          |                |        |
Then Verify the following actions:
    | Action           | Element                        | Type    | Detail | Window |
    | Verifies Content | CASH RECEIPTS ANALYSIS DETAILS | ToolTip |        |        |

