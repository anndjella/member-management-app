# Fitness Studio Management - Client-Server Application

This is a client-server application for managing fitness studio members, monthly invoices, and attendances. The app allows multiple operators to log in and manage different aspects of the studio.

## How to Set Up

### 1. Import the Database

1. Open **SQL Server Management Studio (SSMS)**.
2. Open the SQL script (e.g., with Notepad), select and copy the entire content.
3. Paste the script into a new query window in SSMS.
4. Run the script to create the database.

After running the script, a database named `FitnessStudioDB` will be created. No changes to the connection string are needed - it is located in `App.config`.

---

## How to Run the Application

1. Start the **Server** project first.
   - Press the **'Start server'** button.
2. Then start the **Client** project.
   - Use the default admin credentials already filled in the placeholders to log in.

---

## Application Workflow

### Members Management

- After login, click on **"Members"**.
- All existing members will be listed.
- For each member, you can:
  - Edit their information
  - Search members
  - Delete members

### Monthly Invoice and Attendance

- Before logging any attendance for a member, you must create an invoice for the current month.
- The **current month is automatically generated**.
- Once the invoice is created, you can add attendances (e.g., Pilates, Full Body Workout, etc.).

### Pricing and Categories

- Attendance price depends on the member’s category (e.g., Student, Employed, etc.)

- Each category has its own discount applied.

### Payment Handling

- The operator chooses whether the attendance is **paid** or **unpaid**.
- Paid attendances are excluded from the final monthly invoice.
- Unpaid attendances are included in the invoice.

### Attendance Constraints

- Attendances from previous months **cannot** be entered — only for the **current month**.
- Multiple attendances can be added at once.

### Invoice Details

- Click **"Show details of the selected invoice"** to list all attendances for the selected month.
- The payment status of attendances can be changed later if payment occurs.
- This update is only allowed for **current month invoices**.
