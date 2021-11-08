using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Brewery.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DevisController : ControllerBase
    {
        private readonly ILogger<DevisController> _logger;

        public DevisController(ILogger<DevisController> logger)
        {
            _logger = logger;
        }

        // Demander un devis à un grossiste, en cas de succès, la méthode renvoie un prix et un récapitulatif, en cas d’erreur, elle renvoie une exception et un message pour expliquer la raison
        // o La commande ne peut pas être vide
        // o Le grossiste doit exister
        // o Il ne peut pas y avoir de doublon dans la commande
        // o Le nombre de bières commandé ne doit pas être supérieur au stock du grossiste
        // o La bière doit être vendue par le grossiste
        // o Une réduction de 10 % est appliquée au-dessus de 10 boissons
        // o Une réduction de 20 % est appliquée au-dessus de 20 boissons
        // [HttpPost]
        // public List<DevisDTO> Post(DevisCreateDTO dto)
        // {

        // }

    }
}
