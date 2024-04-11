using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sofidy.Unicia.Domain.Enum
{
    public enum ITyParam
    {

        #region ICONVERT

        // Client
        IConvert_Client = 1,
        // Agent
        IConvert_Agent = 2,
        // Indivisaire
        IConvert_Indivisaire = 8,
        // Mandat
        IConvert_Mandat = 9,
        // Demande
        IConvert_Demande = 10,
        // Intervenant
        IConvert_Intervenant = 11,


        #endregion

        #region PImport

        // Client
        PImport_Client = 38,
        // Agent
        PImport_Agent = 39,
        // Indivisaire
        PImport_Indivisaire = 40,
        // Intervenant
        PImport_Intervenant = 41,
        // KYC
        PImport_KYC = 42,
        // Demande
        PImport_Demande = 43,

        #endregion
    }
}
