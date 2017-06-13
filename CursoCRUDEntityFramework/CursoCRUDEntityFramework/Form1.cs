using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CursoCRUDEntityFramework
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

    private void Cargargrid()
        {
            using (AdventureWorksLT2012Entities Context = new AdventureWorksLT2012Entities())
            {
                IQueryable<Customer> Cliente = from R in Context.Customer select R;
                List<Customer> lista = Cliente.ToList();

                DGCostumer.DataSource = lista;
                DGCostumer.Refresh();
            }
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            Cargargrid();
            
        }

        private void BtnInfo_Click(object sender, EventArgs e)
        {
            int VId = Convert.ToInt32(this.TxtCustomer.Text);
            
            using (AdventureWorksLT2012Entities context = new AdventureWorksLT2012Entities())
            {
                IQueryable<Customer> Cliente = from q in context.Customer
                                               where q.CustomerID == VId 
                                               select q;                   
                List<Customer> lista = Cliente.ToList();
                var oCliente = lista[0];
                ChkNamestyle.Checked = oCliente.NameStyle;
                TxtTitle.Text = oCliente.Title;
                TxtfirstName.Text = oCliente.FirstName;
                TxtmiddleName.Text = oCliente.MiddleName;
                TxtlastName.Text = oCliente.LastName;
                TxtSuffix.Text = oCliente.Suffix;
                TxtCompany.Text = oCliente.CompanyName;
                Txtsalesperson.Text = oCliente.SalesPerson;
                Txtemailaddress.Text = oCliente.EmailAddress;
                Txtphone.Text = oCliente.Phone;
                Txthash.Text = oCliente.PasswordHash;
                Txtsalt.Text = oCliente.PasswordSalt;

            }

        }

        private void TxtCustomer_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtCustomer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                int VId = Convert.ToInt32(this.TxtCustomer.Text);
                using (AdventureWorksLT2012Entities context = new AdventureWorksLT2012Entities())
                {
                    IQueryable<Customer> Cliente = from q in context.Customer
                                                   where q.CustomerID == VId
                                                   select q;
                    List<Customer> lista = Cliente.ToList();
                    var oCliente = lista[0];
                    ChkNamestyle.Checked = oCliente.NameStyle;
                    TxtTitle.Text = oCliente.Title;
                    TxtfirstName.Text = oCliente.FirstName;
                    TxtmiddleName.Text = oCliente.MiddleName;
                    TxtlastName.Text = oCliente.LastName;
                    TxtSuffix.Text = oCliente.Suffix;
                    TxtCompany.Text = oCliente.CompanyName;
                    Txtsalesperson.Text = oCliente.SalesPerson;
                    Txtemailaddress.Text = oCliente.EmailAddress;
                    Txtphone.Text = oCliente.Phone;
                    Txthash.Text = oCliente.PasswordHash;
                    Txtsalt.Text = oCliente.PasswordSalt;

                }
            }

            
        }

        private void Btnagregar_Click(object sender, EventArgs e)
        {
            try
            {
                int CusId = Convert.ToInt32(TxtCustomer.Text);
                if (CusId <=0)
                {
                    //Insertar
                    Insertar();
                }
                else
                {
                    //Actualizar
                    Actualizar();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                Cargargrid();
            }
        }

        private void Actualizar()
        {
            int Cusid = Convert.ToInt32(TxtCustomer.Text);
            using (AdventureWorksLT2012Entities context = new AdventureWorksLT2012Entities())
            {
                Customer oCliente = context.Customer.SingleOrDefault(p => p.CustomerID == Cusid);
                oCliente.NameStyle = ChkNamestyle.Checked;
                oCliente.Title = TxtTitle.Text;
                oCliente.FirstName = TxtfirstName.Text;
                oCliente.MiddleName = TxtmiddleName.Text;
                oCliente.LastName = TxtlastName.Text;
                oCliente.Suffix = TxtSuffix.Text;
                oCliente.CompanyName = TxtCompany.Text;
                oCliente.SalesPerson = Txtsalesperson.Text;
                oCliente.EmailAddress = Txtemailaddress.Text;
                oCliente.Phone = Txtphone.Text;
                oCliente.PasswordHash = Txthash.Text;
                oCliente.PasswordSalt = Txtsalt.Text;

                context.SaveChanges();
            }
        }

        private void Insertar()
        {
            try
            {
                using (AdventureWorksLT2012Entities context = new AdventureWorksLT2012Entities())
                {
                    Customer oCliente = new Customer
                    {
                        NameStyle = ChkNamestyle.Checked,
                        Title = TxtTitle.Text,
                        FirstName = TxtfirstName.Text,
                        MiddleName = TxtmiddleName.Text,
                        LastName = TxtlastName.Text,
                        Suffix = TxtSuffix.Text,
                        CompanyName = TxtCompany.Text,
                        SalesPerson = Txtsalesperson.Text,
                        EmailAddress = Txtemailaddress.Text,
                        Phone = Txtphone.Text,
                        PasswordHash = Txthash.Text,
                        PasswordSalt = Txtsalt.Text,
                        ModifiedDate = DateTime.Now

                    };
                    MessageBox.Show(string.Format("Id ={0} - Lastname{1}",oCliente.CustomerID,oCliente.LastName));

                    context.Customer.Add(oCliente);
                    context.SaveChanges();
                }
            }
                catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        MessageBox.Show(string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage));
                    }
                }
            }

            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message);
            }
            finally
            {
                Cargargrid();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int CusId = Convert.ToInt32(TxtCustomer.Text);

            using (AdventureWorksLT2012Entities context = new AdventureWorksLT2012Entities())
            {
                //Customer ocliente = context.Customer.SingleOrDefault(p => p.CustomerID == CusId);

                Customer oCliente = (from q in context.Customer
                                     where q.CustomerID == CusId
                                     select q).First();
                try
                {
                    context.Customer.Remove(oCliente);
                    context.SaveChanges();
                    Cargargrid();
                }
                catch (Exception Ex)
                {

                    MessageBox.Show(Ex.Message);
                }
            }
        }
    }
}

