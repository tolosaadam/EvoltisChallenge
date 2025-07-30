using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoltisChallenge.Api.Application.Constants;

public static class ValidationMessagesConstants
{
    public const string Null = "{PropertyName} no debe ser nulo.";
    public const string Empty = "{PropertyName} no debe estar vacío.";
    public const string EmptyGuid = "{PropertyName} no debe ser un GUID vacío.";
    public const string InvalidDate = "{PropertyName} tiene una fecha inválida.";
    public const string DefaultDate = "{PropertyName} no puede tener una fecha por defecto.";
    public const string InvalidEmail = "{PropertyName} no tiene un formato válido.";
    public const string GreaterThanZero = "{PropertyName} debe ser mayor a 0.";
}
