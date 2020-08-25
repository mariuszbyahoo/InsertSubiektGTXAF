using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace InsertSubiektGTXAF.Module.BusinessObjects
{
    [DomainComponent]
    [DefaultClassOptions]
    //[ImageName("BO_Unknown")]
    //[DefaultProperty("SampleProperty")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class Asortyment : IXafEntityObject, IObjectSpaceLink, INotifyPropertyChanged
    {
        private IObjectSpace objectSpace;
        public Asortyment(string nazwa, decimal cena, string symbol, string opis)
        {
            Oid = Guid.NewGuid();
            Nazwa = nazwa;
            Cena = cena;
            Symbol = symbol;
            Opis = opis;
        }

        [DevExpress.ExpressApp.Data.Key]
        [Browsable(false)]  // Hide the entity identifier from UI.
        public Guid Oid { get;}

        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Nazwa { get;}
        [EditorBrowsable(EditorBrowsableState.Never)]
        public decimal Cena { get;}
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Symbol { get;}
        public string Opis { get; set; }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (objectSpace != null)
            {
                objectSpace.SetModified(this);
                PropertyChanged?.Invoke(this.objectSpace, new PropertyChangedEventArgs(propertyName));
            }
        }

        #region IXafEntityObject members (see https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppIXafEntityObjecttopic.aspx)
        void IXafEntityObject.OnCreated()
        {
            // Place the entity initialization code here.
            // You can initialize reference properties using Object Space methods; e.g.:
            // this.Address = objectSpace.CreateObject<Address>();
        }
        void IXafEntityObject.OnLoaded()
        {
            // Place the code that is executed each time the entity is loaded here.
        }
        void IXafEntityObject.OnSaving()
        {
            // Place the code that is executed each time the entity is saved here.
        }
        #endregion

        #region IObjectSpaceLink members (see https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppIObjectSpaceLinktopic.aspx)
        // Use the Object Space to access other entities from IXafEntityObject methods (see https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113707.aspx).
        IObjectSpace IObjectSpaceLink.ObjectSpace
        {
            get { return objectSpace; }
            set { objectSpace = value; }
        }
        #endregion

        #region INotifyPropertyChanged members (see http://msdn.microsoft.com/en-us/library/system.componentmodel.inotifypropertychanged(v=vs.110).aspx)
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
    }
}