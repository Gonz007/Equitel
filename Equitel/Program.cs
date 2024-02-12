using AutoMapper;
using Equitel.DTOs;
using Equitel.Models;
using Equitel.Services.Contrato;
using Equitel.Services.Implementacion;
using Equitel.Utilidades;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<EquitelContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultStringConnection"));
});

builder.Services.AddScoped<IProductoService, ProductoService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();



#region Peticiones Producto
app.MapGet("/Producto/lista", async (
    IProductoService _productoService,
    IMapper _mapper
    ) =>
{
    var listaProducto = await _productoService.GetListProducto();
    var listaProductoDTO = _mapper.Map<List<ProductoDTO>>(listaProducto);

    if (listaProductoDTO.Count > 0)
        return Results.Ok(listaProductoDTO);
    else
        return Results.NotFound();
});

//Crear un producto
app.MapPost("/Producto/Guardar", async (
    ProductoDTO modelo,
    IProductoService _productoService,
    IMapper _mapper
    ) =>
{

    var _producto = _mapper.Map<Producto>(modelo);
    var _ProductoCreado = await _productoService.AddProducto(_producto);

    if (_ProductoCreado.Id != 0)
        return Results.Ok(_mapper.Map<ProductoDTO>(_ProductoCreado));
    else
        return Results.StatusCode(StatusCodes.Status500InternalServerError);
});

//Actualizar un producto
app.MapPut("/Producto/actualizar/{idProducto}", async (
    int id,
    ProductoDTO modelo,
    IProductoService _productoService,
    IMapper _mapper
    ) => {

        var _ProductoEncontrado = await _productoService.GetProducto(id);
        if (_ProductoEncontrado is null) return Results.NotFound();

        var _producto = _mapper.Map<Producto>(modelo);

        _ProductoEncontrado.Descripcion = _producto.Descripcion;
        _ProductoEncontrado.Modelo = _producto.Modelo;
        _ProductoEncontrado.CantidadEnBodega = _producto.CantidadEnBodega;
        _ProductoEncontrado.ValorVenta = _producto.ValorVenta;


        var respuesta = await _productoService.UpdateProducto(_ProductoEncontrado);
        if (respuesta)
            return Results.Ok(_mapper.Map<ProductoDTO>(_ProductoEncontrado));
        else
            return Results.StatusCode(StatusCodes.Status500InternalServerError);
    });

app.MapDelete("/Producto/actualizar/{idProducto}", async (

    int id,
    IProductoService _productoService
    ) => {
        var _ProductoEncontrado = await _productoService.GetProducto(id);
        if (_ProductoEncontrado is null) return Results.NotFound();

        var respuesta = await _productoService.DeleteProducto(_ProductoEncontrado);
        if (respuesta)
            return Results.Ok();
        else return Results.StatusCode(StatusCodes.Status500InternalServerError);
    });
#endregion

#region Peticiones Usuario
app.MapGet("/Usuario/lista", async (
    IUsuarioService _usuarioService,
    IMapper _mapper
    ) =>
{
    var listaUsuario = await _usuarioService.GetListUsuario();
    var listaUsuarioDTO = _mapper.Map<List<UsuarioDTO>>(listaUsuario);

    if (listaUsuarioDTO.Count > 0)
        return Results.Ok(listaUsuarioDTO);
    else
        return Results.NotFound();
});

// Crear un usuario
app.MapPost("/Usuario/Guardar", async (
    UsuarioDTO modelo,
    IUsuarioService _usuarioService,
    IMapper _mapper
    ) =>
{
    var usuario = _mapper.Map<Usuario>(modelo);
    var usuarioCreado = await _usuarioService.AddUsuario(usuario);

    if (usuarioCreado.Id != 0)
        return Results.Ok(_mapper.Map<UsuarioDTO>(usuarioCreado));
    else
        return Results.StatusCode(StatusCodes.Status500InternalServerError);
});

// Actualizar un usuario
app.MapPut("/Usuario/Actualizar/{idUsuario}", async (
    int id,
    UsuarioDTO modelo,
    IUsuarioService _usuarioService,
    IMapper _mapper
    ) =>
{
    var usuarioEncontrado = await _usuarioService.GetUsuario(id);
    if (usuarioEncontrado is null) return Results.NotFound();

    var usuario = _mapper.Map<Usuario>(modelo);

    usuarioEncontrado.Nombre = usuario.Nombre;
    usuarioEncontrado.Rol = usuario.Rol;

    var respuesta = await _usuarioService.UpdateUsuario(usuarioEncontrado);
    if (respuesta)
        return Results.Ok(_mapper.Map<UsuarioDTO>(usuarioEncontrado));
    else
        return Results.StatusCode(StatusCodes.Status500InternalServerError);
});

// Eliminar un usuario
app.MapDelete("/Usuario/Eliminar/{idUsuario}", async (
    int id,
    IUsuarioService _usuarioService
    ) =>
{
    var usuarioEncontrado = await _usuarioService.GetUsuario(id);
    if (usuarioEncontrado is null) return Results.NotFound();

    var respuesta = await _usuarioService.DeleteUsuario(usuarioEncontrado);
    if (respuesta)
        return Results.Ok();
    else
        return Results.StatusCode(StatusCodes.Status500InternalServerError);
});


#endregion




app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();
